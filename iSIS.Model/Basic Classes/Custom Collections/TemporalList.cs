using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    [Serializable]
    public class TemporalList<T> : List<T>, ITemporalList<T> where T : class, ITemporal
    {
        public TemporalList()
            : base()
        {
        }

        public TemporalList(IList<T> list)
            : base(list)
        {
        }

        public TemporalList(int anticipatedSize)
            : base(anticipatedSize)
        {
        }

        public virtual T Current
        {
            get { return GetInstance(this, DateTime.Now); }
            set { Add(value); }
        }

        //public virtual new void Add(T newInstance)
        //{
        //    //TemporalList<T>.ExpireOverlappingInstances(this, newInstance);
        //    base.Add(newInstance);
        //}

        public virtual new void Remove(T existingInstance)
        {
            //if (base.Remove(existingInstance))
            //{
            //    bool verified = true;
            //    base.Remove(existingInstance);
            //    if (null != this.VerifyRemove)
            //        verified = this.VerifyRemove(this, existingInstance);
            //    if (verified)
            //        base.Add(existingInstance);
            //}
            base.Remove(existingInstance);
        }

        public static T GetInstance(ITemporalList<T> list, DateTime when)
        {
            foreach (T i in list)
            {
                if (i.EffectivePeriod.IsEffectiveOn(when))
                    return i;
            }
            return default(T);
        }

        #region ITemporalList<T> Members

        public T GetInstance(DateTime when)
        {
            return GetInstance(this, when);
        }

        #endregion ITemporalList<T> Members
    }
}
