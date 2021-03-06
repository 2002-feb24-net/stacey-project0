/****** Object:  StoredProcedure [dbo].[spCustomer_GetByFullName]    Script Date: 3/24/2020 7:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:     Stacey Joseph, Revature, Project 0
-- Create Date: March 24, 2020
-- Description: Search Customers By Name
-- =============================================
ALTER PROCEDURE [dbo].[spCustomer_GetByFullName]
(
    -- Add the parameters for the stored procedure here
    @firstname nvarchar(50) = 'Demon',
    @lastname nvarchar(50) = 'Stration'
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here
    select PreferredStore, FirstName, Lastname 
	from dbo.Customers
	where firstname = @firstname
	and lastname = @lastname;
END
