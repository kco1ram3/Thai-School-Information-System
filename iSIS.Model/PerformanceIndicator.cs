using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class PerformanceIndicator : PersistentTemporalEntity64
    {
        #region persistent
        
        public virtual int SequenceNo { get; set; }
        public virtual float Weight { get; set; }
        public virtual MultilingualString Description { get; set; }
        public virtual ClassLevel ClassLevel { get; set; }
        public virtual ClassLevelOutcome ClassLevelOutcome { get; set; } 
        
        #endregion

        public override void Persist(SessionContext context)
        {
            if (null != Description) Description.Persist(context);
            base.Persist(context);
        }

        public override string ToString()
        {
            return base.ID.ToString() + "-" + this.Description.ToString("th-TH") ;
        }
    }
}
