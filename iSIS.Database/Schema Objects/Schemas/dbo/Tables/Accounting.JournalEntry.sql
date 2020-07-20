CREATE TABLE [dbo].JournalEntry
(
	ID bigint identity(1,1) NOT NULL PRIMARY KEY,
	Discriminator tinyint not null,
	AccountID int,
	Amount money,
	BalanceType tinyint not null default(0),
	PeriodID int,
	PostedTS datetime2,
	SeqNo int,
	TransactionID bigint,
)
