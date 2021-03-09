CREATE PROCEDURE [dbo].[spStockSymbol_Insert]
	@Id int output,
	@StockSymbol char(10)
AS

	set nocount on;

	IF NOT EXISTS (SELECT * FROM StockSymbols
					where @StockSymbol = StockSymbol)

begin

	insert into dbo.StockSymbols(StockSymbol)
		values(@StockSymbol)

		select @Id = @@IDENTITY
end
