/****** Script for SelectTopNRows command from SSMS  ******/

CREATE PROCEDURE application_logs_findbyId
(@id bigint 
)
AS
SELECT TOP (1000) [LogId]
      ,[LogMessage]
      ,[StackTrace]
      ,[LogDate]
  FROM [whatsapp-db].[dbo].[application_logs]
