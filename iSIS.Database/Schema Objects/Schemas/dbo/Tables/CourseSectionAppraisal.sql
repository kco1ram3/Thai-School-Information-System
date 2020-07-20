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
