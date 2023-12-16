CREATE DATABASE DreamerLab4;
USE DreamerLab4;

CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY,
    CompanyName NVARCHAR(255) NOT NULL,
    ContactName NVARCHAR(255) NOT NULL,
    SupplierName NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    City NVARCHAR(255) NOT NULL,
    Country NVARCHAR(255) NOT NULL,

);
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL,
    SupplierID INT,
    UnitPrice DECIMAL(18, 2),
    UnitsInStock INT,
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID),
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
);
CREATE TABLE Customers (
    CustomerID NVARCHAR(255) PRIMARY KEY,
    ContactName NVARCHAR(255) NOT NULL,
);
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID NVARCHAR(255),
    EmployeeID INT,
    OrderDate DATETIME,
    RequiredDate DATETIME,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
);