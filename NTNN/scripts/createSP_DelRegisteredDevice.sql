-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE DelRegisteredDevice
@RegisteredDevicePK int,
@Result bit out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if exists( select 1 from RegisteredDevices where RegisteredDevicePK = @RegisteredDevicePK )
	begin
		SET @Result = 1
		delete from RegisteredDevices where RegisteredDevicePK = @RegisteredDevicePK
	end;
	else
	begin
		SET @Result = 0
	end
END
GO