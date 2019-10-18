CREATE TABLE [dbo].[application_settings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(10) NULL, 
    [Value] NCHAR(1000) NULL, 
    [Group] NVARCHAR(500) NULL, 
    [Description] NVARCHAR(2000) NULL
)
