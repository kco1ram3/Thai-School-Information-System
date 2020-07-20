CREATE TABLE [dbo].DesiredOutcome
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	Discriminator tinyint,
	Code nvarchar(30),
	CurriculumFrameworkID int,
	DefaultGradingSystemID int,
	ParentID int,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	ClassLevelID bigint,
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
)
