CREATE TABLE [dbo].[application_logs]
(
	[LogId] BIGINT NOT NULL PRIMARY KEY, 
    [LogMessage] NVARCHAR(1000) NULL, 
    [StackTrace] NVARCHAR(1000) NULL, 
    [LogDate] DATETIME NULL
)
