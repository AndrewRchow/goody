CREATE PROC UploadedFile_SelectAll
AS
/*
EXECUTE UploadedFile_SelectAll
*/
BEGIN
	SELECT
		Id,
		FileName,
		Size,
		Type,
		SystemFileName,
		CreatedDate,
		ModifiedDate,
		ModifiedBy
	FROM
		UploadedFile
END