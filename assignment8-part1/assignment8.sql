create database Assignment8
use Assignment8

CREATE TABLE Products (
    Pid CHAR(6) PRIMARY KEY,
    PName NVARCHAR(100) NOT NULL,
    PPrice DECIMAL(10, 2) NOT NULL,
    MnfDate DATE NOT NULL,
	ExpDate DATE NOT NULL
)
INSERT INTO Products (Pid, PName, PPrice, MnfDate, ExpDate) VALUES
('P00001', 'ProductA', 19.99, '2022-01-01', '2023-01-01'),
('P00002', 'ProductB', 29.99, '2022-02-15', '2023-02-15'),
('P00003', 'ProductC', 39.99, '2022-03-20', '2023-03-20'),
('P00004', 'ProductD', 49.99, '2022-04-10', '2023-04-10'),
('P00005', 'ProductE', 59.99, '2022-05-05', '2023-05-05'),
('P00006', 'ProductF', 69.99, '2022-06-18', '2023-06-18'),
('P00007', 'ProductG', 79.99, '2022-07-22', '2023-07-22'),
('P00008', 'ProductH', 89.99, '2022-08-30', '2023-08-30'),
('P00009', 'ProductI', 99.99, '2022-09-12', '2023-09-12'),
('P00010', 'ProductJ', 109.99, '2022-10-25', '2023-10-25')