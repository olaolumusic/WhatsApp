CREATE PROCEDURE reports_insertupdate
(
           @Id int,
           @Name nvarchar(50),
           @LoginStatus nvarchar(50),
           @LoginDateAndTime datetime,
           @IPAddress bigint
)

AS

IF EXISTS (SELECT 'Victor' FROM reports where Name = @Name )

BEGIN
      UPDATE reports

	  SET
	       [Id] = @Id,
           [Name] = @Name,
           [LoginStatus] = @LoginStatus,
           [LoginDateAndTime] = @LoginDateAndTime,
           [IPAddress] = @Id

		   WHERE Name = @Name

END
ELSE
BEGIN
INSERT INTO [dbo].[reports]
           ([Id]
           ,[Name]
           ,[LoginStatus]
           ,[LoginDateAndTime]
           ,[IPAddress])
     VALUES
           (@Id,
           @Name,
           @LoginStatus,
           @LoginDateAndTime,
           @IPAddress)

END
