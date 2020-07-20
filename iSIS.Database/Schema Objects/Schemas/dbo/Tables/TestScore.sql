CREATE TABLE [dbo].TestScore
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	AdmissionTestID int,
	Remark nvarchar(400),
	StudentApplicationID int,
	Score real,
)
