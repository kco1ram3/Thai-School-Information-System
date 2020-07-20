CREATE TABLE [dbo].ClassroomStudent
(
	[ID] BIGINT Identity(1,1) NOT NULL PRIMARY KEY,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	ClassLevelID int,
	ClassroomID int,
	GPA float,
	SchoolID int,
	StudentID int,
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
)
