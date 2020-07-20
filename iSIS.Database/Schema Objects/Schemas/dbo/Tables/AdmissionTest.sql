CREATE TABLE [dbo].AdmissionTest
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	AdmissionID int,
	SeqNo int,
	TestFrom datetime2,
	TestTo datetime2,
	DescriptionMLSID bigint,
	TitleMLSID bigint,
)
