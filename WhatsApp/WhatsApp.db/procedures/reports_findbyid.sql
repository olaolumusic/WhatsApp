CREATE PROCEDURE [dbo].[reports_findbyid]
(
@id int 
)
AS
SELECT TOP (1000) [Id]
      ,[Name]
      ,[LoginStatus]
      ,[LoginDateAndTime]
      ,[IPAddress]
  FROM [whatsapp-db].[dbo].[reports]
