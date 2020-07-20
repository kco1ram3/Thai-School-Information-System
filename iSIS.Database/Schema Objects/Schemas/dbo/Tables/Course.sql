CREATE TABLE [dbo].Course
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	Code nvarchar(30),
	CourseNoMLSID bigint,
	DescriptionMLSID bigint,
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
	CreditHours REAL,
	ClassLevelID bigint,
	OutcomeCategoryID int,
	SchoolID int,
	GradingSystemID int,

	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
)
