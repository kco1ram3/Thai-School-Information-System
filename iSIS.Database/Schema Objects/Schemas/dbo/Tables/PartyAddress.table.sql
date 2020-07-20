CREATE TABLE [dbo].[PartyAddress]
(
	ID int identity(1,1) NOT NULL primary key, 
	PartyID int NOT NULL,
	PartyDiscriminator tinyint,
	CategoryID Bigint,
	EffectiveFrom datetime,
	EffectiveTo datetime,
	Reference nvarchar(200),
	Remark nvarchar(400),

	GeographicAddressID int NOT NULL,
)
