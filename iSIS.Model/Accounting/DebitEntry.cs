using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel.Accounting
{
    public class DebitEntry : JournalEntry
    {
        public override void Post(DateTime postedTS)
        {
            if (Account.IncreaseBalanceBy == PostingRule.Debit)
                Account.Balance += Amount;
            else
                Account.Balance -= Amount;
            PostedTS = postedTS;
        }
    }
}
