using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class ExamSchedule : PersistentTemporalEntity64
    {
        public virtual ClassLevel ClassLevel { get; set; }
        
        public virtual DateTimeRange ExamPeriod
        {
            get { return base.EffectivePeriod; }
            set { base.EffectivePeriod = value; }
        }

        public virtual Semester Semester { get; set; }
    }
}
