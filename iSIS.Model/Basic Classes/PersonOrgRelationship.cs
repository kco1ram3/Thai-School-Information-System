using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public abstract class PersonOrgRelationship : PersistentTemporalEntity32
    {
        public virtual string IDNo { get; set; }
        public virtual HierarchicalCategory Category { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Person Person { get; set; }
    }
}
