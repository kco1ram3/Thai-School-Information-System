CREATE TABLE [dbo].Ledger
(
	ID int identity(1,1) NOT NULL PRIMARY KEY,
	DescriptionMLSID bigint,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	OrganizationID int,
	Reference nvarchar(200),
	Remark nvarchar(500),
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
)
