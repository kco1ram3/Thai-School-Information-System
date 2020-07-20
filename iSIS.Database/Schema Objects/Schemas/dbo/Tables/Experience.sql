CREATE TABLE [dbo].Experience
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	PersonID int,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	OrganizationID int,
	OrganizationName nvarchar(200),
	OrganizationAddress nvarchar(200),
	JobDescription nvarchar(200),
)
