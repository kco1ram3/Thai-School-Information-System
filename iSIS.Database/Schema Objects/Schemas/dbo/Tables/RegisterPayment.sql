CREATE TABLE [dbo].[RegisterPayment]
(
	[RegisterPaymentID] INT NOT NULL PRIMARY KEY,
	[RegisterDetailID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Price] [decimal](18, 2) NULL,
	[Unit] [int] NULL,
	[Create_Date] [datetime2](7) NULL,
	[Update_Date] [datetime2](7) NULL,
)
