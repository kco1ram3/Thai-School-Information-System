CREATE TABLE [dbo].AcademicAchievement
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	Code nvarchar(30),
	[Date] datetime2,
	[Description] nvarchar(400),
	Reference nvarchar(200),
	Remark nvarchar(400),
	PersonID int,
	PerformanceIndicatorID int,
)
