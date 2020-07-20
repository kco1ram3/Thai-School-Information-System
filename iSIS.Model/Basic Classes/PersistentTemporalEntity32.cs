using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public abstract class PersistentTemporalEntity32 : PersistentEntity32, ITemporal
    {
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
