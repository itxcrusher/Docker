using System.Collections.Generic;

namespace Admin_Panel.Models
{
    /* ######################################## --------------- User --------------- ######################################## */
    public class User
    {
        int id;
        string name;
        string role;
        int points;
        string status;
        public User(int id, string name, string role, int points, string status)
        {
            this.id = id;
            this.name = name;
            this.role = role;
            this.points = points;
            this.status = status;
        }
        public int getId() { return id; }
        public string getName() { return name; }
        public string getRole() { return role; }
        public int getPoints() { return points; }
        public string getStatus() { return status; }

        public void setId(int id) { this.id = id; }
        public void setName(string name) { this.name = name; }
        public void setRole(string role) { this.role = role; }
        public void setPoints(int points) { this.points = points; }
        public void setStatus(string status) { this.status = status; }
    }

    /* ######################################## --------------- Artwork --------------- ######################################## */
    public class Art
    {
        int id;
        string title;
        string artist;
        int quantity;
        double price;
        public Art(int id, string title, string artist, int quantity, double price)
        {
            this.id = id;
            this.title = title;
            this.artist = artist;
            this.quantity = quantity;
            this.price = price;
        }
        public int getId() { return id; }
        public string getTitle() { return title; }
        public string getArtist() { return artist; }
        public int getQuantity() { return quantity; }
        public double getPrice() { return price; }

        public void setId(int value) { this.id = value; }
        public void setTitle(string title) { this.title = title; }
        public void setArtist(string artist) { this.artist = artist; }
        public void setQuantity(int quantity) { this.quantity = quantity; }
        public void setPrice(double price) { this.price = price; }
    }

    /* ######################################## --------------- Activity Log --------------- ######################################## */
    public class Log
    {
        int id;
        string name;
        string role;
        string activity;
        string time;
        public Log(int id, string name, string role, string activity, string time)
        {
            this.id = id;
            this.name = name;
            this.role = role;
            this.activity = activity;
            this.time = time;
        }
        public int getId() { return id; }
        public string getName() { return name; }
        public string getRole() { return role; }
        public string getActivity() { return activity; }
        public string getTime() { return time; }
        public void setId(int id) { this.id = id; }
        public void setName(string name) { this.name = name; }
        public void setRole(string role) { this.role = role; }
        public void setActivity(string activity) { this.activity = activity; }
        public void setTime(string time) { this.time = time; }
    }
    
}