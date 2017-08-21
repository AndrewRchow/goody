CREATE PROCEDURE [dbo].[Person_Delete]
	@Id int
AS
/*
DECLARE 
	@_id INT = 1;

SELECT * FROM Person;
EXECUTE Person_Delete
	@_id;
SELECT * FROM Person;
*/
BEGIN
	DELETE Person WHERE Id = @Id;
END