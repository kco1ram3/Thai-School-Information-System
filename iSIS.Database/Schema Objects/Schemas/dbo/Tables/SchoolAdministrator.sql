CREATE TABLE [dbo].SchoolAdministrator
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [CategoryID] INT NULL, 
    [PersonID] INT NULL, 
    [SchoolID] INT NULL,
    [EffectiveFrom] DATETIME2 NULL, 
    [EffectiveTo] DATETIME2 NULL, 
    [Reference] NVARCHAR(50) NULL, 
    [Remark] NVARCHAR(500) NULL, 

    StatusID INT NULL, 
)
