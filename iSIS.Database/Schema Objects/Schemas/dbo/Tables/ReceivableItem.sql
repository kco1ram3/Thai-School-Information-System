CREATE TABLE [dbo].[ReceivableItem]
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [EffectiveFrom] DATETIME2 NULL, 
    [EffectiveTo] DATETIME2 NULL, 
    [Reference] NVARCHAR(50) NULL, 
    [Remark] NVARCHAR(50) NULL, 
    [SeqNo] INT NULL, 
    [SchoolID] INT NULL,
	TitleMLSID bigint,
	DefaultAmount money,
)
