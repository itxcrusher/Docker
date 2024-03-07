using Admin_Panel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace Admin_Panel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            User[] users = usersData();
            users = users.OrderByDescending(obj => obj.getPoints()).ToArray();
            Art[] arts = artsData();
            arts = arts.OrderBy(obj => obj.getPrice()).ToArray();

            ViewBag.queueOrders = 3;
            ViewBag.usersData = users;
            ViewBag.artsData = arts;
            ViewBag.activityLog = activityLog();

            return View();
        }
        public User[] usersData()
        {
            string conString = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    var totalUsers = 0;
                    User[] usersData;

                    con.Open();
                    string totalQuery = "SELECT count(*) AS 'Total Users' FROM dbo.Users";
                    SqlCommand totalCmd = new SqlCommand(totalQuery, con);
                    using (SqlDataReader totalReader = totalCmd.ExecuteReader())
                    {
                        if (totalReader.Read())
                        {
                            totalUsers = totalReader.GetInt32(0);
                            usersData = new User[totalUsers];
                        }
                        else
                        {
                            return null;
                        }
                    }
                    for (int i = 0; i < totalUsers; i++)
                    {
                        string userQuery = String.Format("Select * from dbo.Users where Id='{0}'", i + 1);
                        SqlCommand userCmd = new SqlCommand(userQuery, con);
                        using (SqlDataReader userReader = userCmd.ExecuteReader())
                        {
                            if (userReader.Read())
                            {
                                usersData[i] = new User(userReader.GetInt32(0), userReader.GetString(1), userReader.GetString(2), userReader.GetInt32(3), userReader.GetString(4));
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    return usersData;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching user data.");
                return null;
            }
        }

        public Art[] artsData()
        {
            string conString = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    var totalArts = 0;
                    Art[] artsData;

                    con.Open();
                    string totalQuery = "SELECT count(*) AS 'Total Artworks' FROM dbo.Artworks";
                    SqlCommand totalCmd = new SqlCommand(totalQuery, con);
                    using (SqlDataReader totalReader = totalCmd.ExecuteReader())
                    {
                        if (totalReader.Read())
                        {
                            totalArts = totalReader.GetInt32(0);
                            artsData = new Art[totalArts];
                        }
                        else
                        {
                            return null;
                        }
                    }

                    for (int i = 0; i < totalArts; i++)
                    {
                        string artQuery = String.Format("SELECT a.Id, a.Title, u.Name AS 'Artist', a.Quantity, a.Price FROM dbo.Artworks a INNER JOIN dbo.Users u ON a.Artist = u.Id WHERE u.Role = 'Artist' AND a.Id = '{0}'", i + 1);
                        SqlCommand artCmd = new SqlCommand(artQuery, con);
                        using (SqlDataReader userReader = artCmd.ExecuteReader())
                        {
                            if (userReader.Read())
                            {
                                artsData[i] = new Art(userReader.GetInt32(0), userReader.GetString(1), userReader.GetString(2), userReader.GetInt32(3), userReader.GetInt32(4));
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    return artsData;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching arts data.");
                return null;
            }
        }

        public Log[] activityLog()
        {
            string conString = _configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    var totalLogs = 0;
                    Log[] activitylog;

                    con.Open();
                    string totalQuery = "SELECT count(*) AS 'Total Logs' FROM dbo.Log";
                    SqlCommand totalCmd = new SqlCommand(totalQuery, con);
                    using (SqlDataReader totalReader = totalCmd.ExecuteReader())
                    {
                        if (totalReader.Read())
                        {
                            totalLogs = totalReader.GetInt32(0);
                            activitylog = new Log[totalLogs];
                        }
                        else
                        {
                            return null;
                        }
                    }

                    for (int i = 0; i < totalLogs; i++)
                    {
                        string logQuery = String.Format("SELECT l.Id, u.Name, u.Role, l.Act, l.Time FROM dbo.Log l INNER JOIN dbo.Users u ON l.Name = u.Id WHERE l.Id = '{0}'", i + 1);
                        SqlCommand logCmd = new SqlCommand(logQuery, con);
                        using (SqlDataReader userReader = logCmd.ExecuteReader())
                        {
                            if (userReader.Read())
                            {
                                activitylog[i] = new Log(userReader.GetInt32(0), userReader.GetString(1), userReader.GetString(2), userReader.GetString(3), userReader.GetString(4));
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    return activitylog;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching activity log data.");
                return null;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}