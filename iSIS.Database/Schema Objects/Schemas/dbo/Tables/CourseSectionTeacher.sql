CREATE TABLE [dbo].ClassSectionTeacher
(
	[ID] BIGINT Identity(1,1) NOT NULL PRIMARY KEY,
	ClassSectionID bigint,
	TeacherID bigint,

	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
)
