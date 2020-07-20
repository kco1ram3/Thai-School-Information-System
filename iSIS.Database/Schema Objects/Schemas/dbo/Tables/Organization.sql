CREATE TABLE [dbo].Organization
(
	[ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [CurrentNameID] INT NULL, 
    [Discriminator] TINYINT NULL, 
    [EffectiveFrom] DATETIME2 NULL, 
    [EffectiveTo] DATETIME2 NULL, 
	Reference nvarchar(200),
	Remark nvarchar(400),
    [OfficialIDNo] NVARCHAR(50) NULL, 
    [EmailAddress] NVARCHAR(50) NULL, 
    [URL] NVARCHAR(500) NULL, 
    [CategoryID] INT NULL, 
    [SupervisoryOrganizationID] BIGINT NULL, 
    [MaxClassLevelID] INT NULL, 
    [MinClassLevelID] INT NULL
)
