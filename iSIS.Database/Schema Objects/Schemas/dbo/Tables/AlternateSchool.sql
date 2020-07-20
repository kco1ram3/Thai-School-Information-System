CREATE TABLE [dbo].AlternateSchool
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	[Rank] int,
	Reference nvarchar(200),
	Remark nvarchar(400),
	StudentApplicationID int,
	SchoolID int,
)
