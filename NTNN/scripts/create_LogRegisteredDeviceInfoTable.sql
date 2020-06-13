USE [NTNN]
CREATE TABLE [RegisteredDeviceInfo](
	LogPK int PRIMARY KEY NOT NULL IDENTITY(1,1),
	RegisteredDeviceFK int not null Foreign key references RegisteredDevices(RegisteredDevicePK),
	LogJSON nvarchar(max) not null,
	ClassType nvarchar(100),
	LogDate datetime2 not null
)
go