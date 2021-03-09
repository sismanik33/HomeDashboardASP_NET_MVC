CREATE PROCEDURE [dbo].[spStockSymbol_Delete]
	@StockSymbol varchar(10)
AS
begin
	set nocount on;

	delete from dbo.StockSymbols where StockSymbol=@StockSymbol
end
