CREATE TABLE [dbo].ClassSection
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	ClassLevelSectionID bigint,
	CourseID bigint,
	RoomID bigint,
	SchoolID int,
	SemesterID bigint,

	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Remark nvarchar(400),
)
