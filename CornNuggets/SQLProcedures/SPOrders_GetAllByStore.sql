/****** Object:  StoredProcedure [dbo].[spOrders_GetAllByStore]    Script Date: 3/24/2020 8:11:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:     Stacey Joseph, Revature, Project 0
-- Create Date: March 24, 2020
-- Description: Display All Order History Of A Store Location
-- =============================================
ALTER PROCEDURE [dbo].[spOrders_GetAllByStore]
(
    -- Add the parameters for the stored procedure here
    @StoreID int = 1
   
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    SELECT OrderID, DateTimeStamp, CustomerID, Total
	FROM Orders
	WHERE StoreID = @StoreID;
END
