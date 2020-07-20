CREATE TABLE [dbo].ReceiptItem
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [Amount] REAL NULL, 
    [AmountPerUnit] REAL NULL, 
    [Units] INT NULL, 
    [ReceiptID] INT NULL, 
    [ReceivableItemID] INT NULL, 
    [SeqNo] INT NULL

)
