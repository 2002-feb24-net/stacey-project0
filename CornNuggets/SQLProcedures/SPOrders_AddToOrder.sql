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
    @orderID int = 1024,
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
	values(@orderID, 
	@prodID,(Select ProductPrice from Products where ProductID = @prodID )*@ProdQty);
	--update the order log
	update Products
	set Inventory = Inventory - 1
	where ProductID = @prodID;

	-----------------------------------------------------------------------------------------------------
	select max(orderID)
	from Orders
	where customerID = 100000006;
	

END
GO
