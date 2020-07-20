using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSISModel
{
    public class AutomaticGrading : PersistentTemporalTitledEntity64
    {
        public virtual School School { get; set; }
        public virtual DiscreteGrade DiscreteGrade { get; set; }
        public virtual int Percentage { get; set; }
    }
}
