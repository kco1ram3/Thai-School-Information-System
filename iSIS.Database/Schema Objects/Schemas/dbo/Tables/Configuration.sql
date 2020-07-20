CREATE TABLE [dbo].Configuration
(
	[ID] INT identity(1,1) NOT NULL PRIMARY KEY,
	[SystemID] INT NOT NULL,
	EffectiveFrom datetime2 NOT NULL,
	EffectiveTo datetime2,

	AcademicLevelRootID int,
	BloodGroupRootID int,
	CourseCategoryRootID int,
	GenderRootID int,
	MajorRootID int,
	OccupationRootID int,
	RaceRootID int,
	RelativeCategoryID int,
	ReligionRootID int,
	StudentStatusRootID int,
	SchoolPositionRootID int,
	SchoolSupervisorCategoryRootID int,

	DefaultCountryCode nchar(3),
	DefaultDateCultureName nvarchar(30),
	DefaultDateFormat nvarchar(50),
	DefaultLanguageCode nchar(5),

	CurriculumCourseCategoryRootID int,
	RoyalDecorationRootID int,
	GuardianCategoryID int,
	FatherCategoryID int,
	MotherCategoryID int,
	PersonPersonRelationshipCategoryRootID int,
	EducationLevelRootID int,
)
