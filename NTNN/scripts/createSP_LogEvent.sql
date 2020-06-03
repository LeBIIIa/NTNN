CREATE OR ALTER PROCEDURE LogEventGNS3
@EventName nvarchar(100),
@EventJSON nvarchar(max)
AS
	insert into LogNotificationGNS3(EventName, EventJSON, LogDate)
	values(@EventName, @EventJSON, GETDATE())
GO