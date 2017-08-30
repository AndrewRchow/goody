CREATE PROCEDURE [dbo].[Person_Insert]
	@FirstName NVARCHAR(50),
	@MiddleName NVARCHAR(50) = NULL,
	@LastName NVARCHAR(50),
	@DOB DATE,
	@ModifiedBy NVARCHAR(128),
	@Id INT OUTPUT
AS
/*
DECLARE 
	@_id INT,
	@_firstName NVARCHAR(50) = 'Test01',
	@_middleName NVARCHAR(50) = 'T',
	@_lastName NVARCHAR(50) = 'Test01',
	@_dob DATE = '01/01/2001',
	@_modifiedBy NVARCHAR(128) = 'vic';

EXECUTE Person_Insert 
	@_id OUT, 
	@_firstName,
	@_middleName,
	@_lastName,
	@_dob,
	@_modifiedBy;

SELECT @_id;
SELECT * FROM Person
*/
BEGIN
	INSERT INTO Person (FirstName, MiddleName, LastName, DOB, ModifiedBy)
	VALUES (@FirstName, @MiddleName, @LastName, @DOB, @ModifiedBy);

	SET @Id = SCOPE_IDENTITY();
END