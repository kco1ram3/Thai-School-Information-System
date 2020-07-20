CREATE TABLE [dbo].Absence
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	AbsenceHours nvarchar(30),
	CategoryID int,
	[Date] datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	StudentID int,
	ClassSectionID int,
)
