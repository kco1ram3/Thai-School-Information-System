using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public abstract class GradingSystem : PersistentTemporalTitledEntity64
    {
        public virtual new int ID { get; set; }
    }
}
