CREATE TABLE [dbo].[reports]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [LoginStatus] NVARCHAR(50) NULL, 
    [LoginDateAndTime] DATETIME NULL, 
    [IPAddress] BIGINT NULL
)
