CREATE TABLE [dbo].AccountingTransaction
(
	ID bigint identity(1,1) NOT NULL PRIMARY KEY,
	Amount money,
	BalanceType tinyint not null default(0),
	Description nvarchar(400),
	EnteredTS datetime2,
	EntryType tinyint not null default(0),
	GLDate datetime2,
	LedgerID int,
	PostedTS datetime2,
	TransactionDate datetime2,
)
