CREATE PROCEDURE application_logs_insertupdate
(
              @LogId bigint,
              @LogMessage nvarchar(1000),
              @StackTrace nvarchar(1000),
              @LogDate datetime
)

AS

IF EXISTS (SELECT 1 FROM application_logs WHERE LogId = @Logid )
            BEGIN
            
			UPDATE application_logs
   
   SET
            [LogId] = @LogId,
            [LogMessage] = @LogMessage,
            [StackTrace] = @StackTrace,
            [LogDate] = @LogDate
   
   WHERE LogId = @LogId

END
     
	 ELSE 

BEGIN
           INSERT INTO [dbo].[application_logs]
            ([LogId]
           ,[LogMessage]
           ,[StackTrace]
           ,[LogDate])

     VALUES
           (@LogId,
            @LogMessage,
            @StackTrace,
            @LogDate)

END
