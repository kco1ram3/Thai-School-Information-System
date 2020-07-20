CREATE TABLE [dbo].ChartOfAccount
(
	ID int identity(1,1) NOT NULL PRIMARY KEY,
	Balance money not null default(0),
	CurrentPeriodID int,
	Discriminator tinyint not null,
	DescriptionMLSID bigint,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	MonthsPerPeriod int,
	OrganizationID int,
	ParentCategoryID int,
	PostingRule tinyint null,
	Reference nvarchar(200),
	Remark nvarchar(500),
	RootCategoryID int,
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
)
