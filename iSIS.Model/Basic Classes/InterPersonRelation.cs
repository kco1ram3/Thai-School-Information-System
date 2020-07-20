using iSISModel;
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using DevExpress.Web.ASPxTreeList;

namespace iSISModel
{
    public class InterPersonRelation : PartyRelation
    {
        public InterPersonRelation()
        {
        }

        public InterPersonRelation(HierarchicalCategory relationshipCategory, String code, String relationshipNo,
                                int seqNo, int level, Person primaryPerson, Person secondaryPerson,
                                DateTime effectiveDate, String reference, String remark)
            : base(code, effectiveDate, relationshipCategory, primaryPerson, secondaryPerson, relationshipNo, reference, remark)
        {
            this.SeqNo = seqNo;
            this.Level = level;
        }

        #region persistent

        public virtual Person PrimaryPerson
        {
            get { return (Person)base.PrimaryParty; }
            set { base.PrimaryParty = value; }
        }
        public virtual Person SecondaryPerson
        {
            get { return (Person)base.SecondaryParty; }
            set { base.SecondaryParty = value; }
        }
        public virtual int Level { get; set; }
        public virtual int SeqNo { get; set; }

        #endregion persistent

        public static InterPersonRelation GetRelationCurrentOf(SessionContext context, TreeListNode relationshipCategory, Person person, DateTime dateTime)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<InterPersonRelation>();
            crit.Add(Expression.Eq("RelationshipCategory", relationshipCategory));
            crit.Add(Expression.Eq("Person", person));
            addEffectiveCriteria(crit);
            return crit.UniqueResult<InterPersonRelation>();
        }

        private static void addEffectiveCriteria(ICriteria crit)
        {
            crit.Add(Expression.Le("EffectivePeriod.From", DateTime.Now));
            crit.Add(Expression.Ge("EffectivePeriod.To", DateTime.Now));
        }

        public static InterPersonRelation FindCurrent(SessionContext context, Person person)
        {
            ICriteria crit = context.PersistenceSession.CreateCriteria<InterPersonRelation>();
            crit.Add(Expression.Eq("Person", person));
            addEffectiveCriteria(crit);
            return crit.UniqueResult<InterPersonRelation>();
        }
    }
}
