using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class SchoolOutcomeCategoryGrading : PersistentTemporalEntity64
    {
        public virtual GradingSystem GradingSystem { get; set; }
        public virtual OutcomeCategory OutcomeCategory { get; set; }
        public virtual School School { get; set; }
    }
}
