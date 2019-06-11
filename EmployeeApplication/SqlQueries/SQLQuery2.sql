use [Employee Database]

select * from tblemployee
select * from tblLocation

alter proc spInsertValuesIntoEmployeeTbl
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Age int,
@Salary decimal(10,2),
@MaritalStatus bit,
@LocationName nvarchar(50),
@SkillName nvarchar(50)
as
begin
Declare @LocationId int;
Declare @SkillId int;
select @LocationId = [dbo].[tblLocation].[LocationId] from [dbo].[tblLocation] where [LocationName] = @LocationName
select @SkillId = [dbo].[tblSkills].[SkillId] from [dbo].[tblSkills] where [SkillName] = @SkillName
insert into [dbo].[tblEmployee] values(@FirstName,@LastName,@Age,@Salary,@MaritalStatus,@LocationId,@SkillId);
end

spInsertValuesIntoEmployeeTbl 'Harry','Maguire',29,100.00,0

create table tblLoginDetails(
ID int identity(1,1),
UserName nvarchar(50) not null,
UserPassword nvarchar(50) not null,
)

select * from tblLoginDetails

insert into tblLoginDetails values('deepvish','Thor@2019')

update tblLoginDetails
set UserPassword='abc'
where UserName='deepvish'

alter proc spValidateUser
@UserName nvarchar(50),
@UserPassword nvarchar(50)
as
begin
select 1 from [dbo].[tblLoginDetails] where UserName = @UserName and UserPassword = @UserPassword
end

spValidateUser 'deepvish','ab'

create table tblSkills(
SkillId int identity(1,1) primary key,
SkillName nvarchar(50) not null
)

create table tblLocation(
LocationId int identity(1,1) primary key,
LocationName nvarchar(50))

insert into tblSkills values('WCF')

insert into tblLocation values('Thane')

select * from tblLocation

alter table dbo.tblEmployee
add Location int

alter table dbo.tblEmployee
add Skill int

alter table dbo.tblEmployee
add constraint fk_tblLocation_LocationID
foreign key(Location) references tblLocation(LocationId)


alter table dbo.tblEmployee
add constraint fk_tblSkills_SkillID
foreign key(Skill) references tblSKills(SkillId)

select * from tblEmployee
select * from tblSkills
select * from tblLocation

update tblEmployee
set Location = 6
where ID=1003

update tblEmployee
set Skill = 3
where ID=4

select FirstName, LastName, Salary, LocationName, SkillName from tblEmployee inner join tblLocation
on tblEmployee.Location = tblLocation.LocationId inner join tblSkills on
tblEmployee.Skill = tblSkills.SkillId

create proc spGetSkillNames
as
begin
Select SkillName from [dbo].[tblSkills]
end

create proc spGetLocationNames
as
begin
Select LocationName from [dbo].[tblLocation]
end

spGetSkillNames
spGetLocationNames

select * from tblLoginDetails

create proc spRemoveEmployee
@ID int
as
begin
Delete from [dbo].[tblEmployee] where ID= @ID;
end

spRemoveEmployee 1003

select * from tblEmployee

alter proc spGetEmployeeById
@ID int
as
begin
select emp.ID, emp.FirstName, emp.LastName, emp.Age, emp.Salary, emp.MaritalStatus, loc.LocationName, emp.Skill 
from tblEmployee emp inner join tblLocation loc
on emp.Location = loc.LocationId where emp.ID=@ID
end

spGetEmployeeById 1

drop proc spGetEmployeeByName

spGetEmployeeByName 'John','Steve'

alter proc spUpdateEmployeeDetails
@ID int,
@FirstName nvarchar(50),
@LastName nvarchar(50),
@Age int,
@Salary decimal(10,2),
@MaritalStatus int,
@LocationName nvarchar(50)
as
begin
Declare @LocationId int;
select @LocationId = loc.[LocationId] from [dbo].[tblLocation] as loc where loc.LocationName=@LocationName;
update [dbo].[tblEmployee] 
set FirstName = @FirstName, LastName=@LastName, Age=@Age, Salary=@Salary, MaritalStatus=@MaritalStatus, Location=@LocationId
where ID=@ID;
end

spUpdateEmployeeDetails 2,'Barry','Allen',28,700,0,'Banglore'

create table tblEmployeeAudit(
AuditEntry nvarchar(200)
)

create trigger tx_tblEmployeeAudit_ForInsert
on tblEmployeeAudit
for insert
as
begin
Declare @ID int;
Select @ID = ID from inserted ins;
end

create proc spSearchEmpByAge
@Age int
as
begin
Select emp.ID,emp.FirstName,emp.LastName,emp.Age,emp.MaritalStatus from [dbo].[tblEmployee] emp where emp.Age = @Age;
end

create proc spSearchEmpBySalary
@Salary decimal(10,2)
as
begin
Select emp.ID,emp.FirstName,emp.LastName,emp.Age,emp.MaritalStatus from [dbo].[tblEmployee] emp where emp.Salary = @Salary;
end

alter proc spSearchEmpByLocation
@Location nvarchar(50)
as
begin
Declare @LocationId int
Select @LocationId = loc.LocationId from [dbo].[tblLocation] loc where loc.LocationName = @Location;
Select emp.ID,emp.FirstName,emp.LastName,emp.Age,emp.MaritalStatus from [dbo].[tblEmployee] emp where emp.Location = @LocationId;
end

spSearchEmpByAge 34
spSearchEmpBySalary 100
spSearchEmpByLocation 'Chennai'

alter table tblEmployee
drop constraint fk_tblSkills_SkillID

alter table tblEmployee
alter column Skill nvarchar(1000)

select * from tblEmployee

update tblEmployee
set Skill = '.NET, Python, BI'

sp_helptext spGetEmployeeById

create proc spGetSkillsByEmpId
@ID int
as
begin
select Skill from [dbo].[tblEmployee] where ID = @ID;
end

spGetSkillsByEmpId 2

create proc spUpdateEmployeeSkill
@ID int,
@Skills nvarchar(1000)
as
begin
update [dbo].[tblEmployee]
set Skill = @Skills where ID = @ID;
end

spUpdateEmployeeSkill 1, '.NET, Java'