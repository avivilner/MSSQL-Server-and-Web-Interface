-- Create the database if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ProjectDB')
BEGIN
    CREATE DATABASE ProjectDB;
END;

-- Switch to the database
USE ProjectDB;

-- Create the table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Terms' AND xtype='U')
BEGIN
    CREATE TABLE Terms (
        ID INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing ID
        Term NVARCHAR(255) NOT NULL UNIQUE -- Unique term
    );
END;

-- Insert sample data (optional)
IF NOT EXISTS (SELECT * FROM Terms WHERE Term = 'ExampleTerm1')
BEGIN
    INSERT INTO Terms (Term) VALUES ('ExampleTerm1');
END;