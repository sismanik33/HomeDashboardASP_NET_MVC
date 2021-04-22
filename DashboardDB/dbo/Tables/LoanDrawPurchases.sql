CREATE TABLE [dbo].[LoanDrawPurchases]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PurchaseDate] DATETIME2 NOT NULL, 
    [Vendor] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    [Paid] BIT NOT NULL, 
    [PartyToReimburse] NVARCHAR(50) NOT NULL, 
    [PurchaseTotal] MONEY NOT NULL, 
    [DrawNumber] INT NOT NULL, 
    [ReceiptLink] NVARCHAR(150) NULL, 
    [PartialPayment] BIT NULL
)
