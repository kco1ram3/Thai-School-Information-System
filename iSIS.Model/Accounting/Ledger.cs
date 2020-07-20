using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iSISModel;
using NHibernate;

namespace iSISModel.Accounting
{
    public class Ledger : PersistentTemporalTitledEntity32
    {
        #region persistent

        public virtual string Description { get; set; }
        public virtual Organization Organization { get; set; }

        private IList<AccountingTransaction> transactions;
        public virtual IList<AccountingTransaction> Transactions
        {
            get
            {
                if (null == this.transactions)
                    this.transactions = new List<AccountingTransaction>();
                return this.transactions;
            }

            set
            {
                this.transactions = value;
            }
        }

        #endregion persistent

        public virtual IList<AccountingTransaction> Post(SessionContext context, DateTime enteredDate)
        {
            DateTime postedTS = DateTime.Now;
            IList<AccountingTransaction> transactions = context.PersistenceSession
                .QueryOver<AccountingTransaction>()
                .Where(t => t.EnteredTS.Date == enteredDate.Date)
                .List();
            int seqNo = 0;
            foreach (AccountingTransaction t in transactions)
            {
                t.Post(postedTS, ref seqNo);
            }
            return transactions;
        }

        public override void Persist(SessionContext context)
        {
            base.Persist(context);
            foreach (AccountingTransaction t in transactions)
            {
                t.Ledger = this;
                t.Persist(context);
            }
        }
    }
}
