using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class ContinuousGradingSystem : GradingSystem 
    {
        public virtual float MaxPoint { get; set; }
        public virtual float MinPoint { get; set; }
    }
}
