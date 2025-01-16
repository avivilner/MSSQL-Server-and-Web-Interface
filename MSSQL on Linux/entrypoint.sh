#!/bin/bash

# Start SQL Server in the background
/opt/mssql/bin/sqlservr &

# Wait for SQL Server to be ready
echo "Waiting for SQL Server to start..."
until /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Sisma123!" -Q "SELECT 1" &> /dev/null
do
  sleep 2
done

echo "SQL Server is ready. Running initialization script..."

# Run the initialization script
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "Sisma123!" -i /docker-entry/init.sql

echo "Initialization complete."

# Keep SQL Server running
wait
