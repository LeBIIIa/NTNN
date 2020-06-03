CREATE TABLE [LogNotificationGNS3](
	LogPK int PRIMARY KEY NOT NULL IDENTITY(1,1),
	EventName nvarchar(100) not null,
	EventJSON nvarchar(max) not null,
	LogDate datetime2 not null
)
go