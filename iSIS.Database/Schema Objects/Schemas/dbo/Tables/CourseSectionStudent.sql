CREATE TABLE [dbo].ClassSectionStudent
(
	[ID] BIGINT Identity(1,1) NOT NULL PRIMARY KEY,
	ClassSectionID bigint,
	StudentID bigint,
	GradeID int,
	GradePoint real,
	AttendedHours real,

	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
)
