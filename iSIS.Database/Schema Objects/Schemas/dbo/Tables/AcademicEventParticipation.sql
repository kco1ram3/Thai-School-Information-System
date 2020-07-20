CREATE TABLE [dbo].AcademicEventParticipation
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	Code nvarchar(30),
	StartDate datetime2,
	EndDate datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	PersonID int,
	AcademicEventCategoryID int,
	AcademicEventTitle nvarchar(400),
	[Description] nvarchar(400),
	Venue nvarchar(400),
)
