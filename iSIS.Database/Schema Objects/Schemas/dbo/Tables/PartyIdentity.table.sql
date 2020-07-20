CREATE TABLE [dbo].[PartyIdentity]
(
	ID int identity(1,1) NOT NULL primary key, 
	PartyID int NOT NULL,
	PartyDiscriminator tinyint,
	CategoryID int,
	EffectiveFrom datetime,
	EffectiveTo datetime,
	Reference nvarchar(200),
	Remark nvarchar(400),

	IDNo nvarchar(30) NOT NULL,
	IssuedBy int,
)
