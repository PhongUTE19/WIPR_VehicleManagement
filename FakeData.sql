USE WIPR_VehicleManagement;
GO

INSERT INTO dbo.Owner (FirstName, LastName, Phone, Email, Address) VALUES
('Nguyen', 'An', '0901234567', '22110001@student.hcmute.edu.vn', '123 Le Loi, District 1, HCM'),
('Tran', 'Binh', '0902345678', '22110002@student.hcmute.edu.vn', '456 Nguyen Trai, District 5, HCM'),
('Le', 'Cuong', '0903456789', '22110003@student.hcmute.edu.vn', '789 Cach Mang Thang 8, District 10, HCM'),
('Pham', 'Dung', '0904567890', '22110004@student.hcmute.edu.vn', '321 Vo Van Tan, District 3, HCM'),
('Ho', 'Em', '0905678901', '22110005@student.hcmute.edu.vn', '654 Tran Hung Dao, District 1, HCM'),
('Do', 'Giang', '0906789012', '22110006@student.hcmute.edu.vn', '987 Nguyen Dinh Chieu, District 3, HCM'),
('Bui', 'Hoa', '0907890123', '22110007@student.hcmute.edu.vn', '159 Ly Thuong Kiet, District 10, HCM'),
('Dang', 'Khanh', '0908901234', '22110008@student.hcmute.edu.vn', '753 Phan Xich Long, Phu Nhuan, HCM'),
('Vo', 'Lam', '0909012345', '22110009@student.hcmute.edu.vn', '951 Dinh Tien Hoang, Binh Thanh, HCM'),
('Nguyen', 'Minh', '0910123456', '22110010@student.hcmute.edu.vn', '852 Le Van Sy, Tan Binh, HCM');

INSERT INTO dbo.Job (Name, Description) VALUES 
-- Nhóm Chăm sóc xe
('Vehicle Repair', 'Sửa chữa xe hư hỏng, bảo trì định kỳ'),
('Vehicle Washing', 'Rửa xe bằng tay hoặc máy tự động'),
('Parking Attendant', 'Trông coi xe, phát và thu thẻ xe'),

-- Nhóm Dịch vụ thuê xe
('Vehicle Rental', 'Cho khách thuê xe của công ty'),
('Vehicle Lease Management', 'Quản lý hợp đồng thuê xe giữa công ty và khách hàng'),
('Customer Vehicle Leasing', 'Quản lý xe do khách ký gửi để công ty cho thuê'),

-- Nhóm Văn phòng / Hợp đồng
('Contract Processing', 'Xử lý hợp đồng thuê và cho thuê xe'),
('Customer Support', 'Hỗ trợ khách hàng về các dịch vụ và hợp đồng'),
('Data Entry', 'Nhập liệu thông tin xe, hợp đồng, khách hàng vào hệ thống'),

-- Khác (có thể mở rộng sau này)
('Inspection', 'Kiểm tra xe định kỳ trước khi cho thuê hoặc trả xe');

-- Chăm sóc xe
UPDATE Job SET RoleKey = 'Mechanic' WHERE Name IN ('Vehicle Repair', 'Inspection');
UPDATE Job SET RoleKey = 'Washer' WHERE Name = 'Vehicle Washing';
UPDATE Job SET RoleKey = 'ParkingAttendant' WHERE Name = 'Parking Attendant';

-- Văn phòng (có thể thêm nếu cần)
UPDATE Job SET RoleKey = 'Office' WHERE Name IN ('Contract Processing', 'Customer Support', 'Data Entry');

-- Dịch vụ thuê xe (có thể gắn tùy ý, hoặc để linh hoạt)
UPDATE Job SET RoleKey = 'Mechanic' WHERE Name IN ('Vehicle Rental', 'Vehicle Lease Management', 'Customer Vehicle Leasing');

INSERT INTO [User] (firstName, lastName, username, password, email) VALUES
('Nova', 'Le', 'tinh', '1', N'22110077@student.hcmute.edu.vn'),
('Tom', 'Dang', 'tom02', '1', N'22110002@student.hcmute.edu.vn'),
('Anna', 'Pham', 'anna03', '1', N'22110001@student.hcmute.edu.vn');