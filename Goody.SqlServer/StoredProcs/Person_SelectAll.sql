CREATE PROCEDURE [dbo].[Person_SelectAll]
AS
/*
EXECUTE Person_SelectAll
*/
BEGIN
	SELECT
		Id,
		FirstName,
		MiddleName,
		LastName,
		DOB,
		CreatedDate,
		ModifiedDate,
		ModifiedBy
	FROM
		Person
END