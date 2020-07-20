	CREATE TABLE [dbo].[RegisterDetail]
(
	[RegisterDetailID] INT NOT NULL PRIMARY KEY,
	[RegisterID] [int] NOT NULL,
	[Curriculum] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[TeacherID] [int] NOT NULL,
	[Status] [nvarchar](50) NULL,
	[Remark] [nvarchar](200) NULL
)
