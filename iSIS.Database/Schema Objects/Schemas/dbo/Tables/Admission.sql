CREATE TABLE [dbo].Admission
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	AdmissionID int,
	SeqNo int,
	AdmittedClassLevelID int,

 
	ApplicationReceiptTemplateID bigint,
	ApplicationFormURL nvarchar(200),
	ApplicationInfoURL nvarchar(200),
	ApplyFrom datetime2,
	ApplyTo datetime2,
	
	RegistrationFormURL nvarchar(200),
	RegistrationReceiptTemplateID bigint,
	RegistrationInfoURL nvarchar(100),
	RegisterFrom datetime2,
	RegisterTo datetime2,
	
	OrientationDate datetime2,
	TestResultPublishDate datetime2,
	SemesterID int,
	SchoolID int,
	DescriptionMLSID bigint,
)
