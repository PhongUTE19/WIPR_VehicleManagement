IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'WIPR_VehicleManagement')
BEGIN
    CREATE DATABASE WIPR_VehicleManagement;
END;
GO

USE WIPR_VehicleManagement;
GO
IF OBJECT_ID('dbo.Contract', 'U') IS NOT NULL DROP TABLE dbo.Contract;
IF OBJECT_ID('dbo.Vehicle', 'U') IS NOT NULL DROP TABLE dbo.Vehicle;
IF OBJECT_ID('dbo.Owner', 'U') IS NOT NULL DROP TABLE dbo.Owner;
IF OBJECT_ID('dbo.Staff', 'U') IS NOT NULL DROP TABLE dbo.Staff;
IF OBJECT_ID('dbo.Job', 'U') IS NOT NULL DROP TABLE dbo.Job;
IF OBJECT_ID('dbo.[User]', 'U') IS NOT NULL DROP TABLE dbo.[User];
GO
CREATE TABLE dbo.Owner
(
    OwnerId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Phone VARCHAR(20) NULL,
    Email VARCHAR(100) NULL,
    Address VARCHAR(200) NULL
);
CREATE TABLE dbo.Vehicle
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OwnerId INT NOT NULL,
    Type VARCHAR(20) NOT NULL CHECK (Type IN ('Bike', 'Motorbike', 'Car')),
    Brand VARCHAR(50) NOT NULL,
    CheckIn DATETIME NOT NULL,
    Subscription VARCHAR(20) NOT NULL CHECK (Subscription IN ('Hour', 'Day', 'Week', 'Month')),
    Picture VARBINARY(MAX) NULL,

    CONSTRAINT FK_Vehicle_Owner FOREIGN KEY (OwnerId) REFERENCES dbo.Owner(OwnerId)
);
CREATE TABLE dbo.Job
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NULL,
    Description TEXT NULL
);
ALTER TABLE Job ADD RoleKey VARCHAR(50);  -- Thêm cột mới để ánh xạ

CREATE TABLE dbo.Staff
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NULL,
    LastName VARCHAR(50) NULL,
    BirthDate DATE NULL,
    Gender VARCHAR(10) NULL CHECK (Gender IN ('Male', 'Female', 'Other')),
    Phone VARCHAR(20) NULL,
    Address VARCHAR(100) NULL,
    Email VARCHAR(100) NULL,
    Picture VARBINARY(MAX) NULL,
    Role VARCHAR(20) NOT NULL CHECK (Role IN ('Mechanic', 'Washer', 'ParkingAttendant')),
    JobId INT NULL,

    CONSTRAINT FK_Staff_Job FOREIGN KEY (JobId) REFERENCES dbo.Job(Id)
);
CREATE TABLE dbo.[User]
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NULL,
    LastName VARCHAR(50) NULL,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL, -- Lưu hash mật khẩu
    Email VARCHAR(100) NULL
);
CREATE TABLE dbo.Contract
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RefContractId INT NULL, -- Nếu có hợp đồng tham chiếu (nối tiếp)

    Type VARCHAR(20) NOT NULL,
    CustomerId INT NOT NULL,
    VehicleId INT NULL,
    StaffId INT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Description TEXT NULL,

    CONSTRAINT FK_Contract_Customer FOREIGN KEY (CustomerId) REFERENCES dbo.Owner(OwnerId),
    CONSTRAINT FK_Contract_Vehicle FOREIGN KEY (VehicleId) REFERENCES dbo.Vehicle(Id),
    CONSTRAINT FK_Contract_Staff FOREIGN KEY (StaffId) REFERENCES dbo.Staff(Id),
    CONSTRAINT FK_Contract_RefContract FOREIGN KEY (RefContractId) REFERENCES dbo.Contract(Id)
);
ALTER TABLE Contract
ADD customerType VARCHAR(20); -- 'user' hoặc 'owner'
