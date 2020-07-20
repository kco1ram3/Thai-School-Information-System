CREATE TABLE [dbo].[MultilingualString]
(
	[MLSID] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Code nvarchar(20),
	Remark nvarchar(200),
)
