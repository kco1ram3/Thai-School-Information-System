CREATE TABLE [dbo].Semester
(
	[ID] BIGINT Identity(1,1) NOT NULL PRIMARY KEY,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	AcademicYear int,
	SemesterNo int,
	SchoolID int,
	SemesterID bigint,
	ApplicationFrom datetime2,
	ApplicationTo datetime2,
	TeachingFrom datetime2,
	TeachingTo datetime2,
	FinalExamFrom datetime2,
	FinalExamTo datetime2,
)
