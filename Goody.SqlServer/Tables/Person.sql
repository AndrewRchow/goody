CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [MiddleName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [DOB] DATE NOT NULL, 
    [CreatedDate] DATETIME NOT NULL DEFAULT getutcdate(), 
    [ModifiedDate] DATETIME NOT NULL DEFAULT getutcdate(), 
    [ModifiedBy] NVARCHAR(128) NOT NULL
)
