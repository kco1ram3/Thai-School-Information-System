CREATE TABLE [dbo].[ReceiptTemplateItem]
(
	[ID] BIGINT Identity(1,1) NOT NULL PRIMARY KEY, 
    [SeqNo] INT NULL, 
    [ReceiptTemplateID] INT NULL, 
    [ReceivableItemID] INT NULL, 
    [DefaultAmount] REAL NULL, 
    [DefaultAmountPerUnit] REAL NULL, 
    [DefaultUnits] INT NULL

)
