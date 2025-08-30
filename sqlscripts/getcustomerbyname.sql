/****** Object:  StoredProcedure [dbo].[getcustomerbyname]    Script Date: 30/08/2025 9:02:47 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getcustomerbyname] 
	-- Add the parameters for the stored procedure here

--@pages int, @quantityrows int
@name varchar(200)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT c.custid CustomerId,o.orderid OrderId,c.contactname CustomerName, o.requireddate LastOrderDate, DATEDIFF(DAY, o.orderdate, o.requireddate) DiffDays 
	from Sales.Customers c inner join Sales.Orders o on c.custid=o.custid where c.contactname=@name  order by o.orderid desc
	--OFFSET (@pages - 1) * @quantityrows ROWS
    --FETCH NEXT @quantityrows ROWS ONLY;
	 --group by c.custid, o.orderid, c.contactname, o.requireddate, o.orderdate
END
