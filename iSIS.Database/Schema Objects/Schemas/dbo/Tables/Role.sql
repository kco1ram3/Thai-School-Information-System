CREATE TABLE [dbo].[Role]
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	Code nvarchar(30),
	ApplicationID int,
	DescriptionMLSID bigint,
	ShortTitleMLSID bigint,
	TitleMLSID bigint,

	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
)
