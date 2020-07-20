using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iSISModel;

namespace iSISModel.Accounting
{
    public enum BalanceType
    {
        Actual,
        Budget,
        Encumbrance,
    }

    public enum JournalEntryType
    {
        Standard,
        Manual,
        Multiperiod,
        Upgrade,
    }

    public class AccountingTransaction : PersistentEntity64
    {
        #region persistent

        public virtual decimal Amount { get; set; }
        public virtual BalanceType BalanceType { get; set; }
        public virtual string Description { get; set; }
        public virtual JournalEntryType EntryType { get; set; }
        public virtual DateTime EnteredTS { get; set; }
        public virtual DateTime GLDate { get; set; }
        public virtual Ledger Ledger { get; set; }
        public virtual DateTime PostedTS { get; set; }
        public virtual DateTime TransactionDate { get; set; }

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

        #endregion

        public virtual void Post(DateTime postedTS, ref int seqNo)
        {
            this.PostedTS = postedTS;
            foreach (JournalEntry e in Entries)
            {
                e.Post(postedTS);
                e.SeqNo = ++seqNo;
            }
        }

        public override void Persist(SessionContext context)
        {
            base.Persist(context);
            foreach (JournalEntry e in Entries)
            {
                e.Transaction = this;
                e.Persist(context);
            }
        }
    }
}
