CREATE PROCEDURE [dbo].[Person_Update]
	@Id int,
	@FirstName NVARCHAR(50),
	@MiddleName NVARCHAR(50) = NULL,
	@LastName NVARCHAR(50),
	@DOB DATE,
	@ModifiedBy NVARCHAR(128)
AS
/*
DECLARE 
	@_id INT = 3,
	@_firstName NVARCHAR(50) = 'TestUpdate01',
	@_middleName NVARCHAR(50) = 'U',
	@_lastName NVARCHAR(50) = 'TestUpdate01',
	@_dob DATE = '02-02-2002',
	@_modifiedBy NVARCHAR(128) = 'modByVic';

SELECT * FROM Person;
EXECUTE Person_Update 
	@_id, 
	@_firstName,
	@_middleName,
	@_lastName,
	@_dob,
	@_modifiedBy;
SELECT * FROM Person;
*/
BEGIN
	DECLARE @modifiedDate DATETIME = GETUTCDATE();
	UPDATE PERSON
	SET FirstName = @FirstName,
		MiddleName = @MiddleName,
		LastName = @LastName,
		DOB = @DOB,
		ModifiedDate = @modifiedDate,
		ModifiedBy = @ModifiedBy
	WHERE Id = @Id;
END