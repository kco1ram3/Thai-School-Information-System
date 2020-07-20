using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public abstract class Party : PersistentTemporalEntity32
    {
        public virtual string IDNo { get; set; }
        public virtual string OfficialIDNo { get; set; }
        //public virtual string PartyDiscriminator { get; set; }
        private IList<PartyAddress> addresses;
        public virtual IList<PartyAddress> Addresses
        {
            get
            {
                if (null == this.addresses)
                    this.addresses = new List<PartyAddress>();
                return this.addresses;
            }
            set
            {
                this.addresses = value;
            }
        }

        private IList<PartyIdentity> identities;
        public virtual IList<PartyIdentity> Identities
        {
            get
            {
                if (null == this.identities)
                    this.identities = new List<PartyIdentity>();
                return this.identities;
            }
            set
            {
                this.identities = value;
            }
        }

        public virtual PartyAddress GetCurrentAddress(HierarchicalCategory addressCategory)
        {
            foreach (PartyAddress i in this.Addresses)
            {
                if (i.IsEffectiveNow && i.Category.ID == addressCategory.ID)
                    return i;
            }
            return null;
        }

        public virtual PartyIdentity GetCurrentIdentity(HierarchicalCategory identityCategory)
        {
            foreach (PartyIdentity i in this.Identities)
            {
                if (i.IsEffectiveNow && i.Category.ID == identityCategory.ID)
                    return i;
            }
            return null;
        }

        public override void Persist(SessionContext context)
        {
            if (0 == this.ID)
                base.Persist(context);
            foreach (PartyAddress pa in this.Addresses)
            {
                //if (null == pa.Party || pa.Party.ID != this.ID)
                pa.Party = this;
                pa.Persist(context);
            }
            foreach (PartyIdentity pa in this.Identities)
            {
                //if (null == pa.Party || pa.Party.ID != this.ID)
                pa.Party = this;
                pa.Persist(context);
            }

            //context.Persist(this);
        }
    }
}
