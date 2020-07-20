CREATE TABLE [dbo].Photo
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	PersonID int,
	[Date] datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	[Image] ntext,
)
