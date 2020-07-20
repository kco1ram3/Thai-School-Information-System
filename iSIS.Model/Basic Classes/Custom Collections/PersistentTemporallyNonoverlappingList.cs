using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iSISModel.Basic_Classes;
using NHibernate.Collection.Generic;
using NHibernate.Engine;

namespace iSISModel
{
    public class PersistentTemporallyNonoverlappingList<T> : PersistentGenericBag<T>, ITemporallyNonoverlappingList<T> where T : class, ITemporal
    {
        public PersistentTemporallyNonoverlappingList(ISessionImplementor session, IList<T> list)
            : base(session, list)
        {
        }

        public PersistentTemporallyNonoverlappingList(ISessionImplementor session)
            : base(session)
        {
        }
        /// <summary>
        /// instance must be added in chronological order.
        /// </summary>
        /// <param name="instance"></param>
        public virtual void Add(T instance)
        {
            if (null == instance)
                throw new Exception("Instance is null.");

            if (null != this.Current)
                this.Current.EffectivePeriod.Expire(instance.EffectivePeriod.From);

            this.current = instance;

            TemporallyNonoverlappingList<T>.ExpireOverlappingInstances(this, instance);
            base.Add(instance);
        }

        public static void ExpireOverlappingInstances(ITemporalList<T> list, T newInstance)
        {
            DateTimeRange effectivePeriod = newInstance.EffectivePeriod;
            DateTime effectiveDate = effectivePeriod.From;
            //Validate
            foreach (T i in list)
            {
                if (i.EffectivePeriod.From > effectiveDate)
                    throw new Exception("The effective date of the added instance is less than some existing effective dates");
            }

            //Expire the current one
            foreach (T i in list)
            {
                if (i.EffectivePeriod.IsEffectiveOn(effectiveDate))
                    i.EffectivePeriod.ExpiryDate = effectiveDate;
            }
        }

        protected T current;
        public virtual T Current
        {
            get
            {
                if (null == this.current)
                    foreach (T e in this)
                    {
                        if (e.EffectivePeriod.IsEffectiveNow())
                        {
                            this.current = e;
                            break;
                        }
                    }
                return this.current;
            }
            set
            {
                Add(value);
            }
        }

        public T GetInstance(DateTime when)
        {
            return TemporalList<T>.GetInstance(this, when);
        }
    }
}
