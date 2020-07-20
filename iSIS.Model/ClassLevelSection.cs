using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    /// <summary>
    /// ป1/1 ป1/2 ... ม6K ม6Q ม6J
    /// </summary>
    public class ClassLevelSection : PersistentTemporalTitledEntity64
    {
        public virtual ClassLevel ClassLevel { get; set; }

        public virtual School School { get; set; }
        public virtual Semester Semester { get; set; }

        private IList<Classroom> classrooms;
        public virtual IList<Classroom> Classrooms
        {
            get
            {
                if (null == this.classrooms)
                    this.classrooms = new List<Classroom>();
                return this.classrooms;
            }

            set
            {
                this.classrooms = value;
            }
        }
     }
}
