# Base image for SQL Server
FROM mcr.microsoft.com/mssql/server

# Install SQL Server tools
#RUN sudo apt-get update && sudo apt-get install -y mssql-tools
#RUN apt-get update && \
#    apt-get install -y mssql-tools

# Copy the .bacpac file into the container
COPY ArtGallery.bacpac /tmp/ArtGallery.bacpac

# Import the .bacpac file into the SQL Server database
RUN /opt/mssql-tools/bin/sqlpackage /a:Import /tsn:localhost /tu:SA /tp:$SA_PASSWORD /sf:/tmp/ArtGallery.bacpac

# Expose SQL Server port
#EXPOSE 1433

# Run SQL Queries at this path:
# docker-entrypoint-initdb.d