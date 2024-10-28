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

# SQL Aggregate Functions often used with the GROUP BY clause of the SELECT statement

## MIN()

[//]: # (When you use MIN() or MAX(), the returned column will not have a descriptive name. To give the column a descriptive name, use the AS keyword:)

```
SELECT MIN(Price) AS SmallestPrice, CategoryID
FROM Products
GROUP BY CategoryID;
```
