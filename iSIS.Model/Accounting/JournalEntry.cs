using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iSISModel;

namespace iSISModel.Accounting
{
    public abstract class JournalEntry : PersistentEntity64
    {
        #region persistent
        public virtual LedgerAccount Account { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual AccountingPeriod Period { get; set; }
        public virtual DateTime PostedTS { get; set; }
        /// <summary>
        /// Unique for a PostedTS
        /// </summary>
        public virtual int SeqNo { get; set; }
        public virtual AccountingTransaction Transaction { get; set; }

        #endregion persistent
        
        public abstract void Post(DateTime postedTS);

        public override void Persist(SessionContext context)
        {
            base.Persist(context);
        }
    }
}
