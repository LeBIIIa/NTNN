USE [NTNN]
CREATE TABLE [Users](
	UserPK int PRIMARY KEY NOT NULL IDENTITY(1,1),
	[Login] nvarchar(20) not null unique,
	[Password] nvarchar(50) not null,
	CreatedDate datetime2 not null
)
go