Create Table Student
(
	ID int AUTO_INCREMENT,
	FirstName varchar(20),
	LastName varchar(20),
	DateOfBirth datetime,
	Address varchar(100),
	PostalCode char(6),
	PhoneNumber varchar(10),
	Email varchar(40),
	Hours int,
	Belt int
	PrimaryKey(ID)
);