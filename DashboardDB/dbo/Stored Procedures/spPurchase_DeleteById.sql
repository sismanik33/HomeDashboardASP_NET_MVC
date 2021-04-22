CREATE PROCEDURE [dbo].[spPurchase_DeleteById]
	@Id int
AS
begin
	set nocount on;

	DELETE FROM dbo.LoanDrawPurchases WHERE Id=@Id
end