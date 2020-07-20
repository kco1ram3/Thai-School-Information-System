CREATE TABLE [dbo].[User]
(
	[ID] BIGINT NOT NULL PRIMARY KEY, 
    [ApplicationID] INT NULL, 
    LoginName NVARCHAR(50) NULL, 
    [PersonID] BIGINT NULL, 
    [OrganizationID] INT NULL,
	IsDisable bit,
	LastLoginTimestamp DATETIME2,
	LastFailedLoginTimestamp DATETIME2,
	ConsecutiveFailedLoginCount int,
	CurrentPasswordID bigint,

    BirthDate DATETIME2 NULL, 
    DeceasedDate DATETIME2 NULL, 

	EffectiveFrom datetime2,
	EffectiveTo datetime2,
    [Reference] NVARCHAR(50) NULL, 
    [Remark] NVARCHAR(500) NULL, 
)
