alter table Curriculum add
	--SchoolID int,
	StartingClassLevelID int,
	EndingClassLevelID int;

alter table CurriculumCourse add 
    ForClassLevelID int,
    ForSemesterNo int;

alter table ClassSectionStudent add
	TotalScore real;
go

CREATE TABLE [dbo].CourseSectionPerformance
(
	[ID] BIGINT Identity(1,1) NOT NULL PRIMARY KEY,
	CourseSectionAppraisalID int,
	CourseSectionStudentID int,

	AppraisalDate datetime2,
	Score real,
	Remark nvarchar(400),
)
GO

CREATE TABLE [dbo].CourseSectionAppraisal
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	CourseSectionID int,
	SeqNo int,
	PerfectScore real,
	AverageScore real,
	MaxScore real,
	MinScore real,

	AppraisalDate datetime2,
	Title nvarchar(200),
	Description nvarchar(400),
)
GO

CREATE INDEX [CourseSectionAppraisal_IX]
	ON [dbo].CourseSectionAppraisal
	(CourseSectionID, SeqNo)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
go

CREATE UNIQUE NONCLUSTERED INDEX Curriculum_UIX_School ON [dbo].Curriculum
(
	SchoolID,
	EffectiveFrom,
	EffectiveTo,
	StartingClassLevelID,
	EndingClassLevelID
)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
go


exec sp_rename 'ClassSectionStudent', 'CourseSectionStudent'
exec sp_rename 'ClassSectionTeacher', 'CourseSectionTeacher'

exec sp_rename 'ClassSection', 'CourseSection'
exec sp_rename 'CourseSectionStudent.ClassSectionID', 'CourseSectionID'
exec sp_rename 'CourseSectionTeacher.ClassSectionID', 'CourseSectionID'
exec sp_rename 'Absence.ClassSectionID', 'CourseSectionID'
exec sp_rename 'PerformanceMeasurement.ClassSectionID', 'CourseSectionID'

alter table AdmissionTest drop column
	DescriptionMLSID,
	TitleMLSID;

alter table AdmissionTest add
	Description nvarchar(500),
	Title nvarchar(200);

alter table Admission add
	Title nvarchar(200),
	Description nvarchar(500);
