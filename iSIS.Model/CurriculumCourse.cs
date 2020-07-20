using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class CurriculumCourse : PersistentTemporalEntity64
    {
        public virtual HierarchicalCategory Category { get; set; }

        public virtual Course Course { get; set; }

        public virtual Curriculum Curriculum { get; set; }

        public virtual ClassLevel ForClassLevel { get; set; }

        public virtual int ForSemesterNo { get; set; }
    }
}
