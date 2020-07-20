CREATE TABLE [dbo].ReceiptTemplate
(
	[ID] BIGINT Identity(1,1) NOT NULL PRIMARY KEY, 
    [SchoolID] INT NULL, 
    [ReceiptNote] NVARCHAR(100) NULL, 
    [TotalAmount] REAL NULL

)
