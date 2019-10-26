CREATE TABLE [dbo].[user_mamagement]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Username] NVARCHAR(50) NULL, 
    [Firstname] NVARCHAR(50) NULL, 
    [Lastname] NVARCHAR(50) NULL, 
    [Password] NCHAR(10) NULL, 
    [EmailAddress] NVARCHAR(50) NULL
)
