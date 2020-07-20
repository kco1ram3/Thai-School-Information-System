CREATE TABLE [dbo].Classroom
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	ClassLevelSectionID INT,
	SchoolID int,
	RoomID bigint,
	SemesterID bigint,
	SemesterNo int,
	AcademicYear int,
)
