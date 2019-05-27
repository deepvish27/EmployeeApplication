create table tblEmployee(
ID int identity(1,1) primary key,
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(50) NOT NULL,
Age int NOT NULL,
Salary decimal(10,2) NOT NULL,
)

select * from tblEmployee

DBCC checkident(tblEmployee,RESEED,0)

delete from tblEmployee where ID=2

alter table tblEmployee
add constraint chk_AgeLessThanZero
Check (Age > 0)

alter table tblEmployee
add MaritalStatus bit

update tblEmployee
set MaritalStatus = 1
where ID =2

insert into tblEmployee values('John','Steve',36,100.00)
insert into tblEmployee values('Chris','Evans',41,500.00)

create proc spGetEmployeeDetails
as
begin
select [tblEmployee].[ID],[tblEmployee].[FirstName],[tblEmployee].[LastName],[tblEmployee].[Age],[tblEmployee].[MaritalStatus] from [tblEmployee];
end

spGetEmployeeDetails