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
-- Description: Add A New Customer (with feedback)
-- =============================================
ALTER PROCEDURE dbo.spCustomers_AddNew
(
    -- Add the parameters for the stored procedure here
    @FirstName nvarchar(50) = 'Demon',
    @LastName nvarchar(50) = 'Stration',
	@PreferredStore varchar(7) = 'TEXA001'
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    IF NOT EXISTS(SELECT * FROM dbo.Customers WHERE Firstname = @FirstName and LastName = @LastName) 
	BEGIN 
		INSERT INTO Customers values (@FirstName, @LastName, @PreferredStore);
	END
		Select *
		from Customers 
		where LastName = @LastName
		and FirstName = @FirstName;
END
GO
