/****** Object:  StoredProcedure [dbo].[getcustomers]    Script Date: 30/08/2025 9:01:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[getcustomers] 
	-- Add the parameters for the stored procedure here

@pages int, @quantityrows int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT c.custid CustomerId,o.orderid OrderId,c.contactname CustomerName, o.requireddate LastOrderDate, DATEDIFF(DAY, o.orderdate, o.requireddate) DiffDays 
	from Sales.Customers c inner join Sales.Orders o on c.custid=o.custid  order by o.orderid desc
	OFFSET (@pages - 1) * @quantityrows ROWS
    FETCH NEXT @quantityrows ROWS ONLY;
	 --group by c.custid, o.orderid, c.contactname, o.requireddate, o.orderdate
END
