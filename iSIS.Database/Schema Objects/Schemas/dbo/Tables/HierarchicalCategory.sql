CREATE TABLE [dbo].HierarchicalCategory
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	Code nvarchar(30),
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	RootID int,
	ParentID int,
	DescriptionMLSID bigint,
	ShortTitleMLSID bigint,
	TitleMLSID bigint,

	LevelNo int,
	SeqNo int,
	[Weight] real,
)
