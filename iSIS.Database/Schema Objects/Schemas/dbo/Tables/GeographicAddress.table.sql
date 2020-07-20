CREATE TABLE [dbo].[GeographicAddress]
(
	ID bigint identity(1,1) NOT NULL primary key, 
	AddressNoMLSID bigint,
	Street1MLSID bigint,
	Street2MLSID bigint,
	
	PostalCode nvarchar(20),

	ProvinceID bigint, --จังหวัด FK from GeographicRegion
	DistrictID bigint, --อำเภอ FK from GeographicRegion
	SubdistrictID bigint, --ตำบล
	TownID bigint, --หมู่บ้าน FK from GeographicRegion

	CountryID bigint,
)
