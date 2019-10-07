USE [AlfaSampleDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE OR ALTER PROCEDURE [dbo].[spImportInvoice]
   @path VARCHAR(MAX)
AS
BEGIN

DECLARE @sql VARCHAR(MAX)

SET @sql = 'INSERT INTO Invoices SELECT * FROM 
OPENROWSET(''Microsoft.ACE.OLEDB.12.0'',''Excel 12.0; Database=' +  @path + ''',[Sheet1$]);'

PRINT @sql

EXEC (@sql)

END
GO