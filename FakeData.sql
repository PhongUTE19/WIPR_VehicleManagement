USE WIPR_VehicleManagement;
GO

INSERT INTO [Job] (id, name, description) VALUES
(1, 'Mechanic', 'Responsible for vehicle repairs'),
(2, 'Washer', 'Handles vehicle washing and cleaning'),
(3, 'Attendant', 'Manages vehicle parking'),
(4, 'Inspector', 'Inspects vehicle condition'),
(5, 'Technician', 'Maintains vehicle electronics'),
(6, 'Security', 'Guards the parking area'),
(7, 'Cleaner', 'Cleans the parking premises'),
(8, 'Admin', 'Office and record management'),
(9, 'Support', 'Assists staff and customers'),
(10, 'Supervisor', 'Supervises the entire operation');

INSERT INTO [Staff] (id, firstName, lastName, birthdate, gender, phone, address, email, picture, role, job) VALUES
(1, 'John', 'Doe', '1990-01-15', 'Male', '0912345678', 'HCM', 'john@example.com', NULL, 'Mechanic', 'Mechanic'),
(2, 'Alice', 'Smith', '1992-03-10', 'Female', '0912345679', 'HCM', 'alice@example.com', NULL, 'Washer', 'Washer'),
(3, 'Bob', 'Lee', '1985-06-22', 'Male', '0912345680', 'HCM', 'bob@example.com', NULL, 'ParkingAttendant', 'Attendant'),
(4, 'Jane', 'Nguyen', '1994-08-12', 'Female', '0912345681', 'HCM', 'jane@example.com', NULL, 'Mechanic', 'Technician'),
(5, 'David', 'Tran', '1988-04-09', 'Male', '0912345682', 'HCM', 'david@example.com', NULL, 'Washer', 'Cleaner'),
(6, 'Linh', 'Pham', '1993-11-05', 'Female', '0912345683', 'HCM', 'linh@example.com', NULL, 'ParkingAttendant', 'Attendant'),
(7, 'Tom', 'Hoang', '1991-09-30', 'Male', '0912345684', 'HCM', 'tom@example.com', NULL, 'Mechanic', 'Mechanic'),
(8, 'Anna', 'Vo', '1995-12-18', 'Female', '0912345685', 'HCM', 'anna@example.com', NULL, 'Washer', 'Washer'),
(9, 'Chris', 'Le', '1989-07-25', 'Male', '0912345686', 'HCM', 'chris@example.com', NULL, 'ParkingAttendant', 'Supervisor'),
(10, 'Emily', 'Nguyen', '1996-02-14', 'Female', '0912345687', 'HCM', 'emily@example.com', NULL, 'Mechanic', 'Technician'),
(11, 'Thanh', 'Bui', '1990-10-10', 'Male', '0912345688', 'HCM', 'thanh@example.com', NULL, 'Washer', 'Support'),
(12, 'Trang', 'Pham', '1997-01-01', 'Female', '0912345689', 'HCM', 'trang@example.com', NULL, 'ParkingAttendant', 'Attendant'),
(13, 'Kien', 'Dang', '1992-06-06', 'Male', '0912345690', 'HCM', 'kien@example.com', NULL, 'Mechanic', 'Technician'),
(14, 'Mai', 'Ngo', '1987-03-03', 'Female', '0912345691', 'HCM', 'mai@example.com', NULL, 'Washer', 'Washer'),
(15, 'Phong', 'Do', '1986-12-12', 'Male', '0912345692', 'HCM', 'phong@example.com', NULL, 'ParkingAttendant', 'Security');

INSERT INTO [User] (id, firstName, lastName, username, password, email) VALUES
(1, 'Nova', 'Le', 'nova01', '1', N'nova@example.com'),
(2, 'Tom', 'Dang', 'tom02', '1', N'tom@example.com'),
(3, 'Anna', 'Pham', 'anna03', '1', N'anna@example.com'),
(4, 'Jake', 'Tran', 'jake04', '1', N'jake@example.com'),
(5, 'Linh', 'Hoang', 'linh05', '1', N'linh@example.com'),
(6, 'David', 'Le', 'david06', '1', N'david@example.com'),
(7, 'Chris', 'Vo', 'chris07', '1', N'chris@example.com'),
(8, 'Emily', 'Ngo', 'emily08', '1', N'emily@example.com'),
(9, 'Trang', 'Nguyen', 'trang09', '1', N'trang@example.com'),
(10, 'Phong', 'Do', 'phong10', '1', N'phong@example.com');

INSERT INTO [Vehicle] (id, owner, type, brand, checkin, subscription, picture) VALUES
(1, 'Nova', 'Car', 'Toyota', '2025-05-01 08:30', 'Hour', NULL),
(2, 'Tom', 'Bike', 'Yamaha', '2025-05-01 09:15', 'Day', NULL),
(3, 'Anna', 'Motorbike', 'Honda', '2025-05-01 10:00', 'Week', NULL),
(4, 'Jake', 'Car', 'Kia', '2025-05-01 11:00', 'Month', NULL),
(5, 'Linh', 'Bike', 'Suzuki', '2025-05-02 08:45', 'Hour', NULL),
(6, 'David', 'Motorbike', 'SYM', '2025-05-02 09:30', 'Day', NULL),
(7, 'Chris', 'Car', 'Ford', '2025-05-02 10:30', 'Week', NULL),
(8, 'Emily', 'Bike', 'Giant', '2025-05-02 11:45', 'Month', NULL),
(9, 'Trang', 'Motorbike', 'Vespa', '2025-05-03 08:00', 'Hour', NULL),
(10, 'Phong', 'Car', 'Mazda', '2025-05-03 09:00', 'Day', NULL),
(11, 'Nova', 'Bike', 'Trek', '2025-05-03 10:00', 'Week', NULL),
(12, 'Tom', 'Car', 'Hyundai', '2025-05-03 11:15', 'Month', NULL),
(13, 'Anna', 'Motorbike', 'Yamaha', '2025-05-04 08:15', 'Hour', NULL),
(14, 'Jake', 'Bike', 'Asama', '2025-05-04 09:00', 'Day', NULL),
(15, 'Linh', 'Car', 'Chevrolet', '2025-05-04 10:00', 'Week', NULL);
