CREATE TABLE [dbo].UserRole
(
	[ID] INT Identity(1,1) NOT NULL PRIMARY KEY,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	Reference nvarchar(200),
	Remark nvarchar(400),
	UserID int,
	RoleID int,
)
