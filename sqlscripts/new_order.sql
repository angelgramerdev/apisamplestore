SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE new_order 
	-- fields orders

@customerid int,
@employeeid int,
@shipperid int,
@shipname varchar(200),
@shipaddress varchar(200),
@shipcity varchar(200),
@orderdate DateTime,
@requireddate DateTime,
@shippeddate DateTime,
@freight Money,
@shipcountry varchar(100),

--fields order details
@productid int,
@unitprice Money,
@qty smallint,
@discount numeric


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
BEGIN TRY

BEGIN TRANSACTION

INSERT INTO Sales.Orders (
	custid,
	empid,
	orderdate,
	requireddate,
	shippeddate,
	shipperid,
	freight,
	shipname,
	shipaddress,
	shipcity,
	shipcountry)
values(@customerid, @employeeId, @orderdate,@requireddate,@shippeddate,@shipperid, @freight, @shipname, @shipaddress, @shipcity, @shipcountry)

DECLARE @orderid INT;
SET @orderid = SCOPE_IDENTITY();

PRINT 'Inserted ID: ' + CAST(@orderid AS VARCHAR);

INSERT INTO Sales.OrderDetails (orderid,productid,unitprice,qty,discount) values(@orderid, @productid, @unitprice,@qty,@discount)

COMMIT
    PRINT 'Result: ' 
END TRY
BEGIN CATCH

ROLLBACK
    -- Error handling code
    PRINT 'An error occurred:';
    PRINT ERROR_MESSAGE();   -- Shows the error message
    PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR);
    PRINT 'Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR);
    PRINT 'State: ' + CAST(ERROR_STATE() AS VARCHAR);
    PRINT 'Procedure: ' + ISNULL(ERROR_PROCEDURE(), 'N/A');
    PRINT 'Line: ' + CAST(ERROR_LINE() AS VARCHAR);
END CATCH;

END
GO
