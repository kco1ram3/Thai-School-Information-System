CREATE TABLE [dbo].Education
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	PersonID int,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	ShortTitleMLSID bigint,
	TitleMLSID bigint,

	StartDate int,
	GraduatedDate int,
	EducationLevelID int,
	AcademicInstituteName int,
	AcademicInstituteAddress int,
	DegreeTitle int,
	ShortDegreeTitle int,
)
