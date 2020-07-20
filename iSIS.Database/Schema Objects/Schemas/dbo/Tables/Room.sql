CREATE TABLE [dbo].Room
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	Code nvarchar(30),
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),

	SchoolID int,
	BuildingTitle nvarchar(200),
	RoomNo nvarchar(20),

)
