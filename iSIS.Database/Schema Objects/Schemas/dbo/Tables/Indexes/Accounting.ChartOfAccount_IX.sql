CREATE INDEX [ChartOfAccount_IX]
	ON [dbo].ChartOfAccount
	(
		OrganizationID, RootCategoryID, ParentCategoryID
	)
