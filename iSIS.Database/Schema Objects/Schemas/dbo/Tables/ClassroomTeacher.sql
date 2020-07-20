CREATE TABLE [dbo].ClassroomTeacher
(
	[ID] BIGINT Identity(1,1) NOT NULL PRIMARY KEY,

	CategoryID int,	
	ClassroomID int,
	TeacherID int,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	ClassLevelID bigint,
	SchoolID int,
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
)
