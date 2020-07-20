using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class ClassroomStudent : PersistentTemporalEntity64
    {
        public virtual Classroom Classroom { get; set; }

        public virtual Student Student { get; set; }

        public virtual float GPA { get; set; }
    }
}
