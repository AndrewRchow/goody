CREATE PROCEDURE [dbo].[Person_SelectById]
	@Id int
AS
/*
DECLARE 
	@_id INT = 1;

EXECUTE Person_SelectById 
	@_id;
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
	WHERE
		Id = @Id;
END