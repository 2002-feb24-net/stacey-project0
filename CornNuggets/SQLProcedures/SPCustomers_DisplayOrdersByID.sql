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
-- Description: Display All Order History Of A Customer
-- =============================================
ALTER PROCEDURE dbo.spCustomers_DisplayOrdersByID
(
    -- Add the parameters for the stored procedure here
	@CustomerID int = 100000006
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    select o.OrderID, o.DateTimeStamp, o.Total, c.PreferredStore, c.FirstName, c.LastName
	from orders as o
	inner join customers as c
	on o.customerID = c.customerID
	and c.CustomerID = @CustomerID;
END
GO
