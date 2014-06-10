Create Table Student
(
	ID INT PRIMARY KEY,
	FirstName varchar(20),
	LastName varchar(20),
	DateOfBirth datetime,
	Address varchar(100),
	PostalCode char(6),
	PhoneNumber varchar(10),
	Email varchar(40),
	Hours int,
	Belt int,
	Balance decimal(10,2),
	MembershipEndDate datetime
);