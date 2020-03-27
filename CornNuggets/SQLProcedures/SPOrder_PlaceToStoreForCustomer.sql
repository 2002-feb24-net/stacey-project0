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
-- Description: Place Orders To Store Locations For Customers
-- =============================================
ALTER PROCEDURE dbo.spOrders_PlaceToStoreForCustomer
(
    -- Add the parameters for the stored procedure here
    @FirstName nvarchar(50) = 'Demon',
    @LastName nvarchar(50) = 'Stration',
	@ProductID int = 111,
	@ProductQty int = 1
)
AS
BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON

			-- Insert statements for procedure here
			-------------------------------Place and Order for a customer in a store of their preference-------------------------------------------
		/*
		--start an order for a customer at their peferred store, timestamped and order total
		**may need to check if result is scalar (no duplicate first and last names)*/
		insert into Orders (DateTimeStamp,CustomerID, StoreID, Total) 
		values 
		(
			GETDATE(), 
			(Select CustomerID 
			from Customers 
			where lastname = @LastName
			and firstname = @FirstName) ,
			(Select StoreID
			from NuggetStores
			where StoreName = 
				(Select PreferredStore
				from customers
				where lastname = @LastName
				and firstname = @FirstName)),
			(Select ProductPrice
			from Products
			where ProductID = @ProductID)*@ProductQty
		);

		update OrderLog
		set ProductQty = @ProductQty
		where OrderID = (select max(orderID) from Orders where customerID = (Select CustomerID 
			from Customers 
			where lastname = @LastName
			and firstname = @FirstName))
		--add initial order to the log
		insert into OrderLog (OrderID, ProductID, ProductQty, SubTotal)
		values((select max(orderID) from Orders where customerID = (Select CustomerID 
			from Customers 
			where lastname = @LastName
			and firstname = @FirstName)), @ProductID, @ProductQty, 
			(Select ProductPrice from Products where ProductID = @ProductID)*@ProductQty);

		--------------------------------------Decrease inventory----------------------------------------------------------
		update Products
		set Inventory = Inventory - @ProductQty
		where ProductID = @ProductID;


		--------------------------------------Summary of order-------------------------------------------------------------
		exec dbo.spOrders_GetDetails (select max(orderID)
		from Orders
		where customerID = 100000006)

		
		

END
GO
