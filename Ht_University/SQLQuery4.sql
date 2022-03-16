USE University
create table Student(
	Id int identity(1,1) constraint PK_Student primary key,
	Name nvarchar(100),
	Age int
 )

 select * from Student

insert into Student
values
	('Ivan', 19),
	('Masha', 19),
	('Pasha', 18) 
	

create table Groups(
	Id int identity(1,1) constraint PK_Group primary key,
	Name nvarchar(100),
)

select * from Groups

insert into Groups
	(Name)
values
	('Chinese'),
	('English'),
	('Tatarcha'),
	('Russian')

create table StudentInGroups(
	Id int identity(1,1) constraint PK_StudentInGroups primary key,
	StudentId int constraint FK_StudentInGroups_Student references Student(Id),
	GroupId int constraint FK_StudentInGroups_Groups references Groups(Id)
)

select * from StudentInGroups

insert into StudentInGroups
values
	(1,2),
	(1,3),
	(2,1),
	(2,3),
	(2,4),
	(3,1),
	(3,2)
