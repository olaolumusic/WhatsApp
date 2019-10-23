CREATE TABLE [dbo].[application_logs]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [PhoneNumber] BIGINT NULL, 
    [State] NVARCHAR(50) NULL, 
    [Country] NVARCHAR(50) NULL, 
    [DeviceName] NVARCHAR(50) NULL, 
    [TimeDuration] DATETIME NULL, 
    [UserAgent] NCHAR(10) NULL
)
