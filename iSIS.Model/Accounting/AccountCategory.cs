using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel.Accounting
{
    public class AccountCategory : ChartOfAccount
    {
        #region persistent

        private IList<ChartOfAccount> accounts;
        public virtual IList<ChartOfAccount> Accounts
        {
            get
            {
                if (null == this.accounts)
                    this.accounts = new List<ChartOfAccount>();
                return this.accounts;
            }

            set
            {
                this.accounts = value;
            }
        }

        #endregion persistent

        public override void Persist(SessionContext context)
        {
            base.Persist(context);
            foreach (ChartOfAccount a in this.Accounts)
            {
                a.RootCategory = this.RootCategory;
                a.ParentCategory = this;
                a.Persist(context);
            }
        }
    }
}
