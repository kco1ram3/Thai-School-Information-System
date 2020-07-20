CREATE TABLE [dbo].Punishment
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	Code nvarchar(30),
	[Date] datetime2,
	[Description] nvarchar(400),
	Reference nvarchar(200),
	Remark nvarchar(400),
	StudentID int,
	PerformanceIndicatorID int,
	DeductedPoint real,
	WrongDoingCategoryID int,
	PunishmentCategoryID int,
)
