# Use the official SQL Server image
FROM mcr.microsoft.com/mssql/server:latest

# Set environment variables
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=ArtGallery123

# Copy the database backup file into the container
COPY ./backup.bak /var/opt/mssql/backup/backup.bak

# Copy the startup script into the container
COPY ./startup.sh /var/opt/mssql/startup.sh

# Grant execute permissions to the startup script
RUN chmod +x /var/opt/mssql/startup.sh

# Run the startup script when the container starts
CMD ["/bin/bash", "/var/opt/mssql/startup.sh"]