using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Reward : PersistentEntity64
    {
        public virtual HierarchicalCategory Category { get; set; }

        public virtual Student Student { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual string Description { get; set; }
    }
}
