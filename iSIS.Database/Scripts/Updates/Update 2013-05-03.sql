alter table Curriculum add 
	CurriculumFrameworkID int,
	SchoolID int;

alter table CurriculumFramework add Code nvarchar(40);

alter table DesiredOutcome add DefaultGradingSystemID int;
