CREATE TABLE [dbo].CurriculumCourse
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	CategoryID int,
	CurriculumID int,
	CourseID int,
	Reference nvarchar(200),
	Remark nvarchar(400),
    ForClassLevelID int,
    ForSemesterNo int,
)
