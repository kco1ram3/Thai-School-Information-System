CREATE TABLE [dbo].StudentSemester
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	SchoolID int,
	StudentID int,
	SemesterID int,

	BehavioralPoint real,
	ClassLevelID int,
	DeductedPoint real,
	GPA real,

	Reference nvarchar(200),
	Remark nvarchar(400),
)
