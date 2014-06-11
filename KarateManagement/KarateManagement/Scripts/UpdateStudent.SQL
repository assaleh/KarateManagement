  UPDATE `karatemanagement`.`student` 
SET `FirstName` = '{1}',`LastName` = '{2}', `DateOfBirth` = '{3}',`Address` = '{4}', `PostalCode` = '{5}', 
	`PhoneNumber` = '{6}', `Email` = '{7}', `Hours` = '{8}', `Belt` = '{9}', `Balance` = '{10}', `MembershipEndDate` = '{11}' 
WHERE `student`.`ID` = {0};