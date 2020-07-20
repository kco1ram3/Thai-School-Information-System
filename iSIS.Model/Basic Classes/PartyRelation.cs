using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using DevExpress.Web.ASPxTreeList;

namespace iSISModel
{
    [Serializable]
    public abstract class PartyRelation : PersistentTemporalEntity64, ICategorizedTemporal
    {
        public PartyRelation()
        {

        }
        public PartyRelation(string code, DateTime effectiveDate, HierarchicalCategory category, Party first, Party second,
                            string relationshipNo, string reference, string remark)
            : base(effectiveDate, reference, remark)
        {
            this.Category = category;
            this.PrimaryParty = first;
            this.SecondaryParty = second;
            this.RelationshipNo = relationshipNo;
        }

        #region persistent

        public virtual HierarchicalCategory Category { get; set; }
        public virtual string RelationshipNo { get; set; }
        protected virtual Party PrimaryParty { get; set; }
        protected virtual Party SecondaryParty { get; set; }

        #endregion persistent

        public virtual HierarchicalCategory CategoryRoot
        {
            get
            {
                if (null == this.Category) return null;
                return this.Category.Root;
            }
            set { }
        }

        public override String ToString()
        {
            return this.PrimaryParty.ToString()
                + " " + this.SecondaryParty.ToString()
                + " " + this.EffectivePeriod.ToString()
                + " " + this.Category.Code;
        }
    }
}
