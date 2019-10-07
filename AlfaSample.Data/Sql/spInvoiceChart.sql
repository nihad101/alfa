USE [AlfaSampleDb]
GO

DROP PROCEDURE [dbo].[GetInvoiceChartData]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetInvoiceChartData]
   @year int,
   @month int
AS
BEGIN
   SELECT Charge, SUM (Amount) AS Total FROM Invoices 
   WHERE YEAR(InvoiceDate) = @year AND MONTH(InvoiceDate) = @month
   GROUP BY Charge
END
GO