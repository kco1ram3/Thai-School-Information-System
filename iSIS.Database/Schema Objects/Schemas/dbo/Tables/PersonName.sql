CREATE TABLE [dbo].[PersonName]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [PersonID] INT NULL,
    [PrefixMLSID] INT NULL,
    [FirstNameMLSID] BIGINT NULL, 
    [MiddleNameMLSID] BIGINT NULL, 
    [LastNameMLSID] BIGINT NULL, 
    [EffectiveFrom] DATETIME2 NULL, 
    [EffectiveTo] DATETIME2 NULL, 
    [Reference] NVARCHAR(50) NULL, 
    [Remark] NVARCHAR(500) NULL, 
)
