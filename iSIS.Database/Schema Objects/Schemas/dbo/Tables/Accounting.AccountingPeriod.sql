CREATE TABLE [dbo].AccountingPeriod
(
	ID int identity(1,1) NOT NULL PRIMARY KEY,
	AccountID int,
	Balance money not null default(0),
	BeginningBalance money not null default(0),
	EndingBalance money not null default(0),
	FiscalYear int not null,
	PeriodNo int not null,
	BeginDate datetime2,
	EndDate datetime2,
	ClosedDate datetime2,
)
