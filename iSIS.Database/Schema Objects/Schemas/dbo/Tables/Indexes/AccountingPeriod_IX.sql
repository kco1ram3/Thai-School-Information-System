CREATE Unique INDEX [AccountingPeriod_UIX]
	ON [dbo].AccountingPeriod
	(
		AccountID,
		FiscalYear,
		PeriodNo
	)
