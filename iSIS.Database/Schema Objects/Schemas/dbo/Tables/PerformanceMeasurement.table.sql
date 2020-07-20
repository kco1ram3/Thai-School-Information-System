CREATE TABLE [dbo].PerformanceMeasurement
(
	ID bigint identity(1,1) NOT NULL primary key, 
	DescriptionMLSID bigint,
	ClassLevelOutcomeID bigint,
	ClassLevelID bigint,

    EffectiveFrom datetime2,
    EffectiveTo datetime2,

    ClassSectionID int,
	SemesterID int,
	StudentID int,
	PerformanceIndicatorID int,
	SequenceNo int,
    Point real,
)
