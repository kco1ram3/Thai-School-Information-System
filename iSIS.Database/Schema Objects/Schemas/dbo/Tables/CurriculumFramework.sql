CREATE TABLE [dbo].CurriculumFramework
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	Code nvarchar(40),
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
)
