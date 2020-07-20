CREATE TABLE [dbo].[Receipt]
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
    [Date] DATETIME2 NULL,  
    [ReceiptNo] NVARCHAR(50) NULL, 
    [SemesterID] INT NULL, 
    [PayerName] NCHAR(50) NULL, 
    [PayerAddress] NVARCHAR(100) NULL, 
    [SchoolID] INT NULL, 
    [StudentID] INT NULL, 
    [TotalAmount] REAL NULL, 
    [Reference] NVARCHAR(50) NULL, 
    [Remark] NVARCHAR(50) NULL 

)
