CREATE PROCEDURE [dbo].[spPurchase_Update]
	@Id int,
	@PurchaseDate datetime2,
	@Vendor varchar(50),
	@Description nvarchar(50),
	@Paid bit,
	@PartyToReimburse nvarchar(50),
	@PurchaseTotal money,
	@DrawNumber int,
	@ReceiptLink nvarchar(150)
AS
begin
	set nocount on;

	Update dbo.LoanDrawPurchases
	set PurchaseDate=@PurchaseDate, Vendor=@Vendor, [Description]=@Description, Paid=@Paid, 
	PartyToReimburse=@PartyToReimburse, PurchaseTotal=@PurchaseTotal, DrawNumber=@DrawNumber, ReceiptLink=@ReceiptLink
	where Id=@Id
end
