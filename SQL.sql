
CREATE DATABASE CRUD
GO
USE CRUD
GO 
CREATE TABLE Employee
(
id int primary key identity(1,1),
name varchar(50),
city varchar(50),
address varchar(50))

GO
CREATE PROC AddNewEmployeeDetails
@name varchar(50),
@city varchar(50),
@address varchar(50)
AS
BEGIN
INSERT INTO Employee values(@name,@city,@address)
END
GO
CREATE PROC GetEmployees
as
begin
SELECT * FROM Employee
end

go
CREATE PROC UpdateEmpDetails
@id int,
@name varchar(50),
@city varchar(50),
@address varchar(50)
as
begin
UPDATE Employee
set name= @name, city=@city, address=@address
where id=@id
end

go
CREATE PROC DeleteEmpById
@id int
as
begin
DELETE FROM Employee WHERE id=@id
end
