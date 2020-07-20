CREATE TABLE [dbo].PerformanceIndicator
(
	ID int identity(1,1) NOT NULL primary key, 
	DescriptionMLSID bigint,
	ClassLevelOutcomeID bigint,
	ClassLevelID bigint,

    EffectiveFrom datetime2,
    EffectiveTo datetime2,

    SequenceNo int,
    [Weight] real,
)
