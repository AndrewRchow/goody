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

