CREATE TABLE [dbo].Application
(
	[ID] INT NOT NULL PRIMARY KEY,
	Code nvarchar(30),
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	TitleMLSID bigint,
	ShortTitleMLSID bigint,
)
