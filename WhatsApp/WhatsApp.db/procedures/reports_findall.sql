CREATE PROCEDURE [dbo].[reports_findall]
(
@rowStart int = 1,
@rowEnd  int = 10
)
AS
SELECT TOP (1000) [Id]
      ,[Name]
      ,[LoginStatus]
      ,[LoginDateAndTime]
      ,[IPAddress]
  FROM [whatsapp-db].[dbo].[reports]


order by Id desc

