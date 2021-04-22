CREATE PROCEDURE [dbo].[spPurchase_Insert]
	@Id int output,
	@PurchaseDate datetime2,
	@Vendor varchar(50),
	@Description nvarchar(50),
	@Paid bit,
	@PartyToReimburse nvarchar(50),
	@PurchaseTotal money,
	@DrawNumber int,
	@ReceiptLink nvarchar(150),
	@PartialPayment bit

AS
begin
	set nocount on;

	insert into dbo.LoanDrawPurchases(PurchaseDate, Vendor, 
	[Description], Paid, PartyToReimburse, PurchaseTotal, DrawNumber, ReceiptLink, PartialPayment)
	values(@PurchaseDate, @Vendor, 
	@Description, @Paid, @PartyToReimburse, @PurchaseTotal, @DrawNumber, @ReceiptLink, @PartialPayment)

	select @Id = @@IDENTITY
end
