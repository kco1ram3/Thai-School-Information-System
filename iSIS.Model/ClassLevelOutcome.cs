using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class ClassLevelOutcome : DesiredOutcome
    {
        #region persistent
        public virtual ClassLevel ClassLevel { get; set; }

        private IList<PerformanceIndicator> performanceIndicators;
        public virtual IList<PerformanceIndicator> PerformanceIndicators
        {
            get
            {
                if (null == this.performanceIndicators)
                    this.performanceIndicators = new List<PerformanceIndicator>();
                return this.performanceIndicators;
            }

            set
            {
                this.performanceIndicators = value;
            }
        } 
        #endregion

        public override string ToString()
        {
            return base.ID.ToString() + "-" + base.Code;
        }

        public override void Persist(SessionContext context)
        {
            base.Persist(context);

            foreach (PerformanceIndicator s in this.PerformanceIndicators)
            {
                s.ClassLevel = this.ClassLevel;
                s.ClassLevelOutcome = this;
                s.Persist(context);
            }
        }
    }
}
