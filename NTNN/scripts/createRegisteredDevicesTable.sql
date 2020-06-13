USE [NTNN]

CREATE TABLE [RegisteredDevices](
	RegisteredDevicePK int PRIMARY KEY NOT NULL IDENTITY(1,1),
	[IP] binary(4) not null unique,
	[Name] nvarchar(100) not null,
	[Hostname] nvarchar(100) not null,
	[Type] nvarchar(50) not null,
	[Port] int not null
)
go
