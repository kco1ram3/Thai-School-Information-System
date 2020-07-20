using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel.Accounting
{
    public enum PostingRule
    {
        Credit,
        Debit,
    }

    public abstract class ChartOfAccount : PersistentTemporalTitledEntity32
    {
        public virtual decimal Balance { get; set; }
        public virtual string Description { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual AccountCategory ParentCategory { get; set; }
        public virtual AccountCategory RootCategory { get; set; }
    }
}
