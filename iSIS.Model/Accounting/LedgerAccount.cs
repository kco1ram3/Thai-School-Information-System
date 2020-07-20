using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel.Accounting
{
    public class LedgerAccount : ChartOfAccount
    {
        public LedgerAccount()
        {
            this.IncreaseBalanceBy = PostingRule.Credit;
        }

        #region persistent

        public virtual AccountingPeriod CurrentPeriod { get; set; }
        public virtual PostingRule IncreaseBalanceBy { get; set; }
        public virtual int MonthsPerPeriod { get; set; }

        private IList<AccountingPeriod> periods;
        public virtual IList<AccountingPeriod> Periods
        {
            get
            {
                if (null == this.periods)
                    this.periods = new List<AccountingPeriod>();
                return this.periods;
            }

            set
            {
                this.periods = value;
            }
        }

        #endregion persistent

        public virtual AccountingPeriod ClosePeriod()//SessionContext context)
        {
            if (null == CurrentPeriod)
                throw new Exception("There is no current period for account " + Code + ".");

            //Create a closing entry for the current period
            AccountingPeriod previousPeriod = this.CurrentPeriod;
            previousPeriod.EndingBalance = previousPeriod.Balance;

            //Create a new accounting period
            DateTime newBeginDate = previousPeriod.EndDate.AddDays(-1);
            int fiscalYear;
            int periodNo;
            if (previousPeriod.EndDate == this.Organization.FiscalYearEndDate)
            {
                fiscalYear = previousPeriod.FiscalYear + 1;
                periodNo = 1;
            }
            else
            {
                fiscalYear = previousPeriod.FiscalYear;
                periodNo = previousPeriod.PeriodNo + 1;
            }
            this.CurrentPeriod = new AccountingPeriod(
                                        newBeginDate, newBeginDate.AddMonths(this.MonthsPerPeriod).AddDays(-1),
                                        fiscalYear, periodNo, this.Balance);

            return previousPeriod;
        }

        public override void Persist(SessionContext context)
        {
            base.Persist(context);
            foreach (AccountingPeriod e in this.Periods)
            {
                e.Account = this;
                e.Persist(context);
            }
        }
    }
}
