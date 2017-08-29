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
GO

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
GO

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
GO

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
GO

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
GO

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
GO

CREATE TABLE [dbo].[UploadedFile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](128) NOT NULL,
	[Size] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[SystemFileName] [nvarchar](128) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_UploadedFile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UploadedFile] ADD  CONSTRAINT [DF_UploadedFile_CreateDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[UploadedFile] ADD  CONSTRAINT [DF_UploadedFile_ModifiedDate]  DEFAULT (getutcdate()) FOR [ModifiedDate]
GO