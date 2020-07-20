CREATE TABLE [dbo].RoyalDecoration
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	[Date] datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	RoyalDecorationCategoryID int,
	PersonID int,
)
