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
    @orderID int = 1001
  
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    select ol.OrderID, ol.SubTotal, ol.ProductID, o.DateTimeStamp, c.PreferredStore, c.FirstName, c.LastName
	from Customers as c, orderlog as ol, orders as o
	where ol.orderID = o.orderID
	and c.CustomerID = o.CustomerID
	and ol.orderid = @orderID 
	order by ol.ProductID;
END
GO
