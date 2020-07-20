using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class ClassroomTeacher : PersistentTemporalEntity64
    {
        public virtual HierarchicalCategory Category { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
