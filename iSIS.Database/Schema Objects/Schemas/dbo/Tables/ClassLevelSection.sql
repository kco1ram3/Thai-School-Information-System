CREATE TABLE [dbo].ClassLevelSection
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	ClassLevelID INT,
	SchoolID int,
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
)
