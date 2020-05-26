CREATE OR ALTER PROCEDURE LogEvent
@EventName nvarchar(100),
@EventJSON nvarchar(max)
AS
	insert into LogNotification(EventName, EventJSON, LogDate)
	values(@EventName, @EventJSON, GETDATE())
GO