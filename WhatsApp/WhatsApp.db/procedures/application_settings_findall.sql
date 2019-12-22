CREATE PROCEDURE application_settings_findall
(@rowStart int =1,
@rowEnd int =10
)
AS
SELECT TOP (@rowEnd) [Id]
      ,[Name]
      ,[Value]
      ,[Group]
      ,[Description]
  FROM [whatsapp-db].[dbo].[application_settings]

  order by Id desc