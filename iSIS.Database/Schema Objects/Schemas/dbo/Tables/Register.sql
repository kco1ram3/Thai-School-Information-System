CREATE TABLE [dbo].[Register]
(
	[RegisterID] INT NOT NULL PRIMARY KEY,
	[UserID] [int] NOT NULL,
	[SemesterID] [int] NOT NULL,
	[SchoolID] [int] NOT NULL,
	[Subject_Amount] [int] NULL,
	[Create_Date] [datetime2](7) NULL,
	[Update_Date] [datetime2](7) NULL
)
