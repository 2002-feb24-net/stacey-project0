-- =======================================================
-- Create Stored Procedure Template for Azure SQL Database
-- =======================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Stacey Joseph
-- Create Date: Revature Training, Project 0
-- Description: Add to Existing Order
-- =============================================
ALTER PROCEDURE spOrders_AddToOrder
(
    -- Add the parameters for the stored procedure here
    @prodID int = 111,
    @ProdQty int = 1,
	@customerID int = 100000006
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    --insert the order data into the orderlog for the next item
	insert into OrderLog (OrderID, ProductID, SubTotal)
	values((select max(orderID) from Orders where customerID = @customerID), 
	@prodID,(Select ProductPrice from Products where ProductID = @prodID)*@ProdQty);
	--update the order log
	update Products
	set Inventory = Inventory - 1
	where ProductID = @prodID;

	-----------------------------------------------------------------------------------------------------

	

	--order details
	select ol.OrderID, ol.SubTotal, ol.ProductID, o.DateTimeStamp, c.PreferredStore, c.FirstName, c.LastName
	from Customers as c, orderlog as ol, orders as o
	where ol.orderID = o.orderID
	and c.CustomerID = o.CustomerID
	and ol.orderid = (select max(orderID) from Orders where customerID = @customerID)
	order by ol.ProductID;
END
GO
