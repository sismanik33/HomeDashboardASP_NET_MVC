﻿CREATE PROCEDURE [dbo].[spPurchases_GetAll]

AS
begin
	set nocount on;
	SELECT Id, PurchaseDate, Vendor,[Description], Paid, 
	PartyToReimburse, PurchaseTotal, DrawNumber, ReceiptLink, PartialPayment
	from dbo.LoanDrawPurchases

end

RETURN 0
