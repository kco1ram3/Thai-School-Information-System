CREATE TABLE [dbo].CourseSectionPerformance
(
	[ID] BIGINT Identity(1,1) NOT NULL PRIMARY KEY,
	CourseSectionAppriasalID int,
	CourseSectionStudentID int,

	AppraisalDate datetime2,
	Score real,
	Remark nvarchar(400),
)
