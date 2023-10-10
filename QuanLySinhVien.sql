-- Tạo cơ sở dữ liệu QuanLySinhVien
CREATE DATABASE QuanLySinhVien;
USE QuanLySinhVien;

-- Tạo bảng USERS
CREATE TABLE USERS (
    username VARCHAR(50) PRIMARY KEY,
    password VARCHAR(50) NOT NULL,
    role VARCHAR(50) NOT NULL
);

-- Tạo bảng STUDENTS
CREATE TABLE STUDENTS (
    MASV VARCHAR(50) PRIMARY KEY,
    Hoten VARCHAR(50),
    Email VARCHAR(50),
    SoDT VARCHAR(50),
    Gioitinh VARCHAR(10),
    Diachi VARCHAR(50),
    Hinh VARCHAR(50)
);

-- Tạo bảng GRADE 
CREATE TABLE GRADE (
    ID INT PRIMARY KEY,
    MASV VARCHAR(50),
    Tienganh INT,
    Tinhoc INT,
    GDTC INT,
    CONSTRAINT FK_STD_GRADE FOREIGN KEY (MASV) REFERENCES STUDENTS(MASV)
);

-- Thêm dữ liệu vào bảng STUDENTS
INSERT INTO STUDENTS
VALUES
    ('SV001', 'TẠ MINH PHƯỚC', 'phuoctm@gmail.com', '0338527706', 'Nam', 'Cà Mau', NULL),
    ('SV002', 'LÊ THỊ HẢI VÂN', 'vanlth@gmail.com', '0238570347', 'Nữ', 'Cà Mau', NULL);

-- Thêm dữ liệu vào bảng GRADE
INSERT INTO GRADE
VALUES
    (1, 'SV001', 10, 10, 10),
    (2, 'SV002', 1, 1, 1);

-- Thêm dữ liệu vào bảng USERS
INSERT INTO USERS
VALUES
    ('admin', '1234', 'Admin'),
    ('gv01', '1234', 'Giảng Viên');
