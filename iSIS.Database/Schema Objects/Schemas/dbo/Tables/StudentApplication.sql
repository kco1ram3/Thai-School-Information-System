CREATE TABLE [dbo].StudentApplication
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	[Date] datetime2,
	AdmissionID int,
	AdmissionTestRoomID int,
	Reference nvarchar(200),
	Remark nvarchar(400),
	IDNo nvarchar(20),
	AppliedCurriculumID int,
	AppliedDate datetime2,
	ApplicantID int,
	FatherID int,
	GuardianID int,
	MotherID int,
	StudentID int,
	LastSchoolID int,
	LastClassLevelID int,
	GPA real,
	ONETScore real,
	TotalTestScore real,
	[Rank] int,
	IsAdmitted bit
)
