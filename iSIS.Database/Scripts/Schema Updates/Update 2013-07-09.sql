alter table Organization add
	FiscalYearEndDate datetime2,
	ChartOfAccountID int
;
go
alter table AdmitCurriculum add TestResultPublishedDate datetime2;
go

CREATE TABLE [dbo].ChartOfAccount
(
	ID int identity(1,1) NOT NULL PRIMARY KEY,
	Balance money not null default(0),
	Discriminator tinyint not null,
	Description nvarchar(500),
	--DescriptionMLSID bigint,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	OrganizationID int,
	ParentCategoryID int,
	IncreaseBalanceBy tinyint,
	Reference nvarchar(200),
	Remark nvarchar(500),
	RootCategoryID int,
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
)
go
CREATE TABLE [dbo].Ledger
(
	ID int identity(1,1) NOT NULL PRIMARY KEY,
	Description nvarchar(500),
	--DescriptionMLSID bigint,
	EffectiveFrom datetime2,
	EffectiveTo datetime2,
	OrganizationID int,
	Reference nvarchar(200),
	Remark nvarchar(500),
	ShortTitleMLSID bigint,
	TitleMLSID bigint,
)

go
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
go
CREATE TABLE [dbo].JournalEntry
(
	ID bigint identity(1,1) NOT NULL PRIMARY KEY,
	Discriminator tinyint not null,
	AccountID int,
	Amount money,
	BalanceType tinyint not null default(0),
	PostedTS datetime2,
	SeqNo int,
	TransactionID bigint,
)
go
CREATE INDEX [AccountingTransaction_IX]
	ON [dbo].AccountingTransaction
	(
		LedgerID
	)
go
CREATE INDEX [ChartOfAccount_IX]
	ON [dbo].ChartOfAccount
	(
		OrganizationID, RootCategoryID, ParentCategoryID
	)
go
CREATE INDEX JournalEntry_IX_Account
	ON [dbo].JournalEntry
	(
		AccountID
	)
go
CREATE INDEX [JournalEntry_IX_Transaction]
	ON [dbo].JournalEntry
	(
		TransactionID
	)
go
