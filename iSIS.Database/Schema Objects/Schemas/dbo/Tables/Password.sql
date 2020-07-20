CREATE TABLE [dbo].Password
(
	[ID] BIGINT NOT NULL PRIMARY KEY, 
    [UserID] INT NULL, 
	EncryptedPassword nvarchar(512),

    [EffectiveFrom] DATETIME2 NULL, 
    [EffectiveTo] DATETIME2 NULL, 
    [Reference] NVARCHAR(50) NULL, 
    [Remark] NVARCHAR(500) NULL, 
)
