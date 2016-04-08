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
-- Author:		Kaz
-- Create date: 04/08/2016
-- Description:	RemoveDVD
-- =============================================
CREATE PROCEDURE DeleteDVD 
	-- Add the parameters for the stored procedure here
	@DvdID int 
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM DvdActor
	WHERE DvdID = @DvdID

	DELETE FROM BorrowInfo
	WHERE DvdID = @DvdID

	DELETE FROM DVDCatalog
	WHERE DvdID = @DvdID

END
GO
