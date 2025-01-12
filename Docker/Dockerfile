# Use the official Microsoft SQL Server image as the base
FROM mcr.microsoft.com/mssql/server:2022-latest

# Switch to the root user
USER root

# Set environment variables for MSSQL
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Sisma123!

# Expose the default SQL Server port
EXPOSE 1433

# Copy the initialization SQL script into the container
COPY ./init.sql /docker-entry/init.sql
#COPY ./entrypoint.sh /usr/src/entrypoint.sh

# Run the initialization script to set up the database
#RUN /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Sisma123! -i /docker-entry/init.sql || exit 0

# Make the entrypoint script executable
#RUN chmod +x /usr/src/entrypoint.sh

# Specify the entry point for the SQL Server process # Start SQL Server
CMD ["/opt/mssql/bin/sqlservr"]
#CMD ["/bin/bash", "/usr/src/entrypoint.sh"]
