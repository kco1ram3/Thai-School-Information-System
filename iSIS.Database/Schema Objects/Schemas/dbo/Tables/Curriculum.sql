CREATE TABLE [dbo].Curriculum
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	CurriculumFrameworkID int,
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
	SchoolID int,
	StartingClassLevelID int,
	EndingClassLevelID int,
	Reference nvarchar(200),
	Remark nvarchar(400),
)
