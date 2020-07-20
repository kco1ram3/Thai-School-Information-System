CREATE TABLE [dbo].SchoolOutcomeCategoryGrading
(
	[ID] int Identity(1,1) NOT NULL PRIMARY KEY,
	Code nvarchar(30),
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	GradingSystemID int,
	OutcomeCategoryID int,
	SchoolID int,
)
