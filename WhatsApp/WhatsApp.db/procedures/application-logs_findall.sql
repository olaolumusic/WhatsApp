CREATE PROCEDURE application_logs_findall
(@rowStart int =1,
@rowEnd int = 10
)
AS
SELECT TOP (@rowEnd) [LogId]
          ,[LogMessage]
          ,[StackTrace]
          ,[LogDate]
FROM [whatsapp-db].[dbo].[application_logs]

  order by LogId desc