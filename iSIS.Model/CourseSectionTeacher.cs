using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class CourseSectionTeacher : PersistentTemporalEntity64
    {
        public virtual CourseSection CourseSection { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
