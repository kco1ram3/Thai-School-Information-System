CREATE TABLE [dbo].DiscreteGrade
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	Symbol nvarchar(8),
	Point real,
	[Description] nvarchar(400),
	GradingSystemID bigint,
)
