using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class DiscreteGrade : PersistentTemporalTitledEntity64
    {
        public virtual string Symbol { get; set; } //A B+ B ... F or 4 3.5 3 ...
        public virtual string Description { get; set; } //A B+ B ... F or 4 3.5 3 ...
        public virtual float Point { get; set; }
        public virtual DiscreteGradingSystem GradingSystem { get; set; }
    }
}
