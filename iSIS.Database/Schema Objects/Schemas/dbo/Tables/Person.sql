CREATE TABLE [dbo].[Person]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [CurrentNameID] INT NULL, 
	BloodGroupNodeID int,
	CitizenOfCountryID int,
	GenderID int,
	EmailAddress NVARCHAR(50),
	HomePhoneNo NVARCHAR(50),
	MobilePhoneNo NVARCHAR(50),
	OccupationID int,
    [OfficialIDNo] NVARCHAR(20) NULL,
	RaceID int,
	ReligionID int,

    BirthDate DATETIME2 NULL, 
    BirthCertificate nvarchar(30), 
    DeceasedDate DATETIME2 NULL, 
    DeathCertificate nvarchar(30), 
    [Reference] NVARCHAR(50) NULL, 
    [Remark] NVARCHAR(500) NULL, 
)
