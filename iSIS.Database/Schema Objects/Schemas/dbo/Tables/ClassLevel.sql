CREATE TABLE [dbo].ClassLevel
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	CategoryID int,
	Code nvarchar(30),
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	LevelNo int,
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
)
