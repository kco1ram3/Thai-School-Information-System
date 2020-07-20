CREATE TABLE [dbo].[GeographicRegion]
(
	ID int identity(1,1) primary key, 
	Code nvarchar(10),
	TitleMLSID bigint,
	CountryID int,
	ParentID int,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
)
