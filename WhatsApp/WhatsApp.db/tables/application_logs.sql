CREATE TABLE [dbo].[application_logs]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(500) NOT NULL, 
    [PhoneNumber] BIGINT NULL, 
    [State] NVARCHAR(200) NULL, 
    [Country] NVARCHAR(200) NULL, 
    [DeviceName] NVARCHAR(200) NULL, 
    [TimeDuration] DATETIME NULL, 
    [UserAgent] NVARCHAR(500) NULL
)


