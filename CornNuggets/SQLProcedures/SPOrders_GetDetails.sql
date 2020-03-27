-- =======================================================
-- Create Stored Procedure Template for Azure SQL Database
-- =======================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:     Stacey Joseph, Revature, Project 0
-- Create Date: March 24, 2020
-- Description: Display Details Of An Order
-- =============================================
ALTER PROCEDURE dbo.spOrders_GetDetails
(
    -- Add the parameters for the stored procedure here
    @orderID int = 1024
  
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    select o.*, u.CustomerID
	from Orders as o, customers as U where 
    orderID = @orderID
END
GO
