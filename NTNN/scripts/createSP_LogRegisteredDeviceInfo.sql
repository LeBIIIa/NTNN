USE [NTNN]
GO

/****** Object:  StoredProcedure [dbo].[AddRegisteredDevice]    Script Date: 13.06.2020 15:16:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER   PROCEDURE [dbo].[LogRegisteredDeviceInfo]
@RegisteredDeviceFK int,
@LogJSON nvarchar(max),
@ClassType nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	insert into RegisteredDeviceInfo(RegisteredDeviceFK, LogJSON, ClassType, LogDate)
	values(@RegisteredDeviceFK, @LogJSON, @ClassType, GETDATE())
END

GO


