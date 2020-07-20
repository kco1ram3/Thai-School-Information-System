CREATE TABLE [dbo].A
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	Code nvarchar(30),
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	ClassLevelID bigint,
	SchoolID int,
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
)
