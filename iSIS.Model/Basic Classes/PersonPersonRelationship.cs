using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class PersonPersonRelationship : PersistentTemporalEntity64
    {
        public virtual string RelationshipIDNo { get; set; }
        public virtual HierarchicalCategory Category { get; set; }
        public virtual Person FirstPerson { get; set; }
        public virtual Person SecondPerson { get; set; }
    }
}
