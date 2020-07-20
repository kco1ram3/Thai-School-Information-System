using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel.Accounting
{
    public class AccountingPeriod : PersistentEntity32
    {

        public AccountingPeriod()
        {
        }

        public AccountingPeriod(DateTime beginDate, DateTime endDate, int fiscalYear, int periodNo, decimal beginningBalance)
        {
            // TODO: Complete member initialization
            this.BeginDate = beginDate;
            this.EndDate = endDate;
            this.FiscalYear = fiscalYear;
            this.PeriodNo = periodNo;
            this.BeginningBalance = beginningBalance;
        }

        #region persistent
        
        public virtual LedgerAccount Account { get; set; }
        public virtual int FiscalYear { get; set; }
        public virtual int PeriodNo { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual decimal BeginningBalance { get; set; }
        public virtual decimal EndingBalance { get; set; }
        public virtual DateTime BeginDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual DateTime ClosedDate { get; set; }

        private IList<JournalEntry> entries;

        public virtual IList<JournalEntry> Entries
        {
            get
            {
                if (null == this.entries)
                    this.entries = new List<JournalEntry>();
                return this.entries;
            }

            set
            {
                this.entries = value;
            }
        }

        #endregion persistent

        //public virtual DateTime PeriodStartDate { get; set; }
        //public virtual DateTime PeriodEndDate { get; set; }

        public virtual bool IsClosed()
        {
            return ClosedDate == DateTime.MinValue || ClosedDate <= DateTime.Today;
        }

        public override void Persist(SessionContext context)
        {
            base.Persist(context);
            foreach (JournalEntry e in this.Entries)
            {
                e.Period = this;
                e.Persist(context);
            }
        }
    }
}
