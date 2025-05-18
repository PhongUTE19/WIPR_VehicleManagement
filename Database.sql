IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'WIPR_VehicleManagement')
BEGIN
	CREATE DATABASE WIPR_VehicleManagement;
END;
GO

USE WIPR_VehicleManagement;
GO

IF OBJECT_ID('dbo.[Job]', 'U') IS NOT NULL
    DROP TABLE dbo.[Job];
GO

IF OBJECT_ID('dbo.[Staff]', 'U') IS NOT NULL
    DROP TABLE dbo.[Staff];
GO

IF OBJECT_ID('dbo.[User]', 'U') IS NOT NULL
    DROP TABLE dbo.[User];
GO

IF OBJECT_ID('dbo.[Vehicle]', 'U') IS NOT NULL
    DROP TABLE dbo.[Vehicle]
GO

CREATE TABLE [dbo].[Job]
(
    [id] INT NOT NULL,
);

CREATE TABLE [dbo].[Staff]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [firstName] VARCHAR(10) NULL, 
    [lastName] VARCHAR(10) NULL,
    [birthdate] DATE NULL,
    [gender] VARCHAR(10) NULL,
    [phone] VARCHAR(10) NULL,
    [address] VARCHAR(10) NULL,
    [email] VARCHAR(10) NULL,
    [picture] IMAGE NULL,
    [role] VARCHAR(10) NULL,
    [job] VARCHAR(10) NULL,
    CHECK ([role]='Mechanic' OR [role]='Washer' OR [role]='ParkingAttendant')
)

CREATE TABLE [dbo].[User]
(
    [id]        INT          NOT NULL,
    [firstName] VARCHAR (10) NULL,
    [lastName]  VARCHAR (10) NULL,
    [username]  VARCHAR (10) NOT NULL,
    [password]  VARCHAR (10) NOT NULL,
    [email]     NCHAR (50)   NULL,
);

CREATE TABLE [dbo].[Vehicle]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [owner] VARCHAR(10) NULL, 
    [type] VARCHAR(10) NULL,
    [brand] VARCHAR(10) NULL,
    [checkin] DATETIME NULL,
    [subscription] VARCHAR(10) NULL,
    [picture] IMAGE NULL,
    CHECK ([type]='Bike' OR [type]='Motorbike' OR [type]='Car'),
    CHECK ([subscription]='Hour' OR [subscription]='Day' OR [subscription]='Week' OR [subscription]='Month'),
)
