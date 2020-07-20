using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public abstract class PersistentTemporalEntity64 : PersistentEntity64, ITemporal
    {
        public PersistentTemporalEntity64()
        {
        }

        public PersistentTemporalEntity64(DateTime effectiveDate, string reference, string remark)
        {
            this.EffectivePeriod = new DateTimeRange(effectiveDate);
            this.Reference = reference;
            this.Remark = remark;
        }
        #region persistent
        
        public virtual DateTimeRange EffectivePeriod { get; set; }

        #endregion persistent

        public virtual bool IsEffectiveOn(DateTime when)
        {
            if (null == this.EffectivePeriod) return false;
            return this.EffectivePeriod.IsEffectiveOn(when);
        }

        public virtual bool IsEffectiveNow
        {
            get
            {
                if (null == this.EffectivePeriod) return false;
                return this.EffectivePeriod.IsEffectiveNow();
            }
        }
    }
}
