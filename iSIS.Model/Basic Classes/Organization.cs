using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iSISModel.Accounting;

namespace iSISModel
{
    public class Organization : Party
    {
        public virtual DateTime FiscalYearEndDate { get; set; }

        public virtual AccountCategory ChartOfAccount { get; set; }

        public virtual OrgName CurrentName { get; set; }

        private IList<OrgName> names;
        public virtual IList<OrgName> Names
        {
            get
            {
                if (null == this.names)
                    this.names = new List<OrgName>();
                return this.names;
            }

            set
            {
                this.names = value;
            }
        }

        private IList<User> users;
        public virtual IList<User> Users
        {
            get
            {
                if (null == this.users)
                    this.users = new List<User>();
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }

        public virtual HierarchicalCategory Category { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string URL { get; set; }

        public override void Persist(SessionContext context)
        {
            base.Persist(context);
            foreach (OrgName n in Names)
            {
                n.Organization = this;
                n.Persist(context);
            }
        }
    }
}
