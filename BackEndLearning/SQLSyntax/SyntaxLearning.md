| CustomerID | CustomerName                       | ContactName        | Address          | City        | PostalCode | Country |
| ---------- | ---------------------------------- | ------------------ | ---------------- | ----------- | ---------- | ------- |
| 1          | Alfreds Futterkiste                | Maria Anders       | Obere Str. 57    | Berlin      | 12209      | Germany |
| 2          | Ana Trujillo Emparedados y helados | Ana Trujillo       | Avda. de la 2222 | México D.F. | 05021      | Mexico  |
| 3          | Antonio Moreno Taquería            | Antonio Moreno     | Mataderos 2312   | México D.F. | 05023      | Mexico  |
| 4          | Around the Horn                    | Thomas Hardy       | 120 Hanover Sq.  | London      | WA1 1DP    | UK      |
| 5          | Berglunds snabbköp                 | Christina Berglund | Berguvsvägen 8   | Luleå       | S-958 22   | Sweden  |

# Select all records from the Customers table:

```
SELECT * FROM Customers;
```

# Return CustomerName, City from the Customers table:

```
SELECT CustomerName, City FROM Customers;
```

# DELETE FROM Customers table WHERE condition:

```
DELETE FROM Customers WHERE Country='Mexico';
```

# Specify both the column names and the values to be inserted.

```
INSERT INTO table_name (column1, column2, column3, ...)
VALUES (value1, value2, value3, ...);:
```

```
INSERT INTO Customers (CustomerName, ContactName, Address, City, PostalCode, Country)
VALUES ('Cardinal', 'Tom B. Erichsen', 'Skagen 21', 'Stavanger', '4006', 'Norway');
```

# CREATE DATABASE databasename;

```
CREATE DATABASE testDB;
```

# ALTER TABLE statement is used to add, delete, or modify columns in an existing table

## To add a column in a table

```
ALTER TABLE table_name
ADD column_name datatype;
```

```
ALTER TABLE Customers
ADD Email varchar(255);
```

## To delete a column in a table

```
ALTER TABLE table_name
DROP COLUMN column_name;
```

```
ALTER TABLE Customers
DROP COLUMN Email;
```

## drop an existing table in a database

```
DROP TABLE table_name;
```

```
DROP TABLE  Customers
```

## The CREATE TABLE statement is used to create a new table

```
CREATE TABLE table_name (
column1 datatype,
column2 datatype,
column3 datatype,
....
);
```

```
CREATE TABLE Persons (
PersonID int,
LastName varchar(255),
FirstName varchar(255),
Address varchar(255),
City varchar(255)
);
```

# ORDER BY

```
SELECT * FROM Products
ORDER BY Price;
```

# AND based on WHERE

```
SELECT *
FROM Customers
WHERE Country = 'Spain' AND CustomerName LIKE 'G%';
```

# OR based on WHERE

```
SELECT *
FROM Customers
WHERE Country = 'Germany' OR Country = 'Spain';
```

# IS/IS NOT NULL

```
SELECT CustomerName, ContactName, Address
FROM Customers
WHERE Address IS/IS NOT NULL;
```

# Update

```
UPDATE Customers
SET ContactName = 'Alfred Schmidt', City= 'Frankfurt'
WHERE CustomerID = 1;
```

# delete

```
DELETE FROM Customers WHERE CustomerName='Alfreds Futterkiste';
```

# Select Top

[//]: # 'the first 3 records'

```
SELECT TOP 3 * FROM Customers;
```

```
SELECT TOP 3 * FROM Customers
WHERE Country='Germany';
```

# SQL Aggregate Functions(MIN(), MAX(), COUNT(), SUM(), AVG()) often used with the GROUP BY clause of the SELECT statement

## MIN()

[//]: # (When you use MIN() or MAX(), the returned column will not have a descriptive name. To give the column a descriptive name, use the AS keyword)
[//]: # (The GROUP BY statement groups rows that have the same values into summary rows, like "find the number of customers in each country".)

```
SELECT MIN(Price) AS SmallestPrice, CategoryID
FROM Products
GROUP BY CategoryID;
```

## COUNT()

[//]: # 'to return the number of records for each categoryID'

```
SELECT COUNT(*) AS [Number of records], CategoryID
FROM Products
GROUP BY CategoryID;
```

## SUM()

[//]: # 'to return the Quantity for each OrderID'

```
SELECT OrderID, SUM(Quantity) AS [Total Quantity]
FROM OrderDetails
GROUP BY OrderID;
```

## SUM() With an Expression

[//]: # (Join OrderDetails with Products, and use SUM() to find the total amount)

```
SELECT SUM(Price * Quantity)
FROM OrderDetails
LEFT JOIN Products ON OrderDetails.ProductID = Products.ProductID;
```

## AVG()

```
SELECT AVG(Price) AS AveragePrice, CategoryID
FROM Products
GROUP BY CategoryID;
```

# IN is a shorthand for multiple OR conditions

```
SELECT * FROM Customers
WHERE Country IN ('Germany', 'France', 'UK');
```

# BETWEEN

```
SELECT * FROM Products
WHERE Price BETWEEN 10 AND 20
AND CategoryID IN (1,2,3);
```

# Joins

## INNER JOIN and JOIN will return the same result.

[//]: # 'INNER is the default join type for JOIN, so when you write JOIN the parser actually writes INNER JOIN'

```
SELECT Products.ProductID, Products.ProductName, Categories.CategoryName
FROM Products
INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID;
```

## LEFT JOIN returns all records from the left table, even if there are no matches in the right table

```
SELECT Customers.CustomerName, Orders.OrderID
FROM Customers
LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID
ORDER BY Customers.CustomerName;
```

## RIGHT JOIN

## FULL OUTER JOIN

# HAVING was added to SQL because the WHERE keyword cannot be used with aggregate functions

[//]: # (return the number of customers in each country, sorted high to low (Only include countries with more than 5 customers))

```
SELECT COUNT(CustomerID), Country
FROM Customers
GROUP BY Country
HAVING COUNT(CustomerID) > 5
ORDER BY COUNT(CustomerID) DESC;
```

# SELECT INTO copies data from one table into a new table

```
SELECT column1, column2, column3, ...
INTO newtable
FROM oldtable
WHERE condition;
```

# Case once a condition is true, it will stop reading and return the result

```
SELECT OrderID, Quantity,
CASE
    WHEN Quantity > 30 THEN 'The quantity is greater than 30'
    WHEN Quantity = 30 THEN 'The quantity is 30'
    ELSE 'The quantity is under 30'
END AS QuantityText
FROM OrderDetails;
```

# Stored Procedure if you have an SQL query that you write over and over again, save it as a stored procedure, and then just call it to execute it

## No parameters

```
CREATE PROCEDURE SelectAllCustomers
AS
SELECT * FROM Customers
GO;
```

```
EXEC SelectAllCustomers;
```

## With Parameters

```
CREATE PROCEDURE SelectAllCustomers @City nvarchar(30)
AS
SELECT * FROM Customers WHERE City = @City
GO;
```

```
EXEC SelectAllCustomers @City = 'London';
```

```
CREATE PROCEDURE SelectAllCustomers @City nvarchar(30), @PostalCode nvarchar(10)
AS
SELECT * FROM Customers WHERE City = @City AND PostalCode = @PostalCode
GO;
```

```
EXEC SelectAllCustomers @City = 'London', @PostalCode = 'WA1 1DP';
```

# Primary Key and Foreign Key

```
CREATE TABLE Orders (
    OrderID int NOT NULL,
    OrderNumber int NOT NULL,
    PersonID int,
    PRIMARY KEY (OrderID),
    FOREIGN KEY (PersonID) REFERENCES Persons(PersonID)
);
```

# Check

[//]: # 'start from 1, it will increment by 1 for each new recordx'

```
CREATE TABLE Persons (
    ID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
    CHECK (Age>=18)
);
```

# Default

```
CREATE TABLE Persons (
    ID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
    City varchar(255) DEFAULT 'Sandnes'
);
```

# Auto Increment

```
CREATE TABLE Persons (
    Personid int NOT NULL AUTO_INCREMENT,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
    PRIMARY KEY (Personid)
);
```
