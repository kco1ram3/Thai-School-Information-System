
CREATE TABLE [dbo].[ClassSectionStudentPoint](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ClassSectionStudentID] [bigint] NOT NULL,
	[Seq] [int] NOT NULL,
	[Point] [real] NULL,
	[Remark] [nvarchar](400) NULL
) ON [PRIMARY]
