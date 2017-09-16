CREATE TABLE [dbo].[PersonPicture]
(
	[PersonId] INT NOT NULL , 
    [UploadedFileId] INT NOT NULL, 
    PRIMARY KEY ([PersonId], [UploadedFileId])
)
