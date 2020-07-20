CREATE INDEX GeographicRegion_IX_CountryID
	ON [dbo].GeographicRegion
	(CountryID asc, ParentID asc )
