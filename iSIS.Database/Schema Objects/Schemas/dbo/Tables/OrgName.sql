CREATE TABLE [dbo].[OrgName]
(
	[ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [OrganizationID] INT NULL, 
    [TitleMLSID] BIGINT NULL, 
    [ShortTitleMLSID] BIGINT NULL, 
    [EffectiveFrom] DATETIME2 NULL, 
    [EffectiveTo] DATETIME2 NULL, 
    [Reference] NVARCHAR(50) NULL, 
    [Remark] NVARCHAR(500) NULL
)
