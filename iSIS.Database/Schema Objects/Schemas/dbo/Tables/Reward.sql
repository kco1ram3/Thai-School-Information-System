CREATE TABLE [dbo].Reward
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	Code nvarchar(30),
	[Date] datetime2,
	[Description] nvarchar(400),
	Reference nvarchar(200),
	Remark nvarchar(400),
	CategoryID int,
	StudentID int,
)
