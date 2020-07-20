CREATE INDEX JournalEntry_IX_AccountingPeriod
	ON [dbo].JournalEntry
	(
		PeriodID
	)