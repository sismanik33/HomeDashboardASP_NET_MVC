CREATE PROCEDURE [dbo].[spStockSymbol_GetAll]

AS
begin
	set nocount on

	select Id, StockSymbol 
	from dbo.StockSymbols

end
