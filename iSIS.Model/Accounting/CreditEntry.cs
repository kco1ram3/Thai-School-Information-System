using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel.Accounting
{
    public class CreditEntry : JournalEntry
    {
        public override void Post(DateTime postedTS)
        {
            if (Account.IncreaseBalanceBy == PostingRule.Credit)
                Account.Balance += Amount;
            else
                Account.Balance -= Amount;
            PostedTS = postedTS;
        }
    }
}
