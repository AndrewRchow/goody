CREATE PROC [dbo].[UploadedFile_Delete]
	@Id INT
AS
/*
EXECUTE [dbo].[UploadedFile_Delete] 1;
*/
BEGIN
	DELETE
		[dbo].[UploadedFile]
	OUTPUT
		[DELETED].[Id],
		[DELETED].[FileName],
		[DELETED].[Size],
		[DELETED].[Type],
		[DELETED].[SystemFileName],
		[DELETED].[CreatedDate],
		[DELETED].[ModifiedDate],
		[DELETED].[ModifiedBy]
	WHERE
		[Id] = @Id;
END