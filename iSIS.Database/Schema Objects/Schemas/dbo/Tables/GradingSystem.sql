CREATE TABLE [dbo].GradingSystem
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	Discriminator tinyint,
	Code nvarchar(30),
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
	MaxPoint real,
	MinPoint real,
)
