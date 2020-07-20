using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class AcademicAchievement : PersistentEntity64
    {
        public virtual Person Person { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual PerformanceIndicator PerformanceIndicator { get; set; }
        public virtual string Description { get; set; }
    }
}
