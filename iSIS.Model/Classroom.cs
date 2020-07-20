using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Classroom : PersistentTemporalEntity64
    {
        #region persistent

        public virtual long ID { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual ClassLevelSection ClassLevelSection { get; set; }
        public virtual PhysicalRoom Room { get; set; }
        public virtual School School { get; set; }

        private IList<ClassroomTeacher> classroomteachers;
        public virtual IList<ClassroomTeacher> ClassroomTeachers
        {
            get
            {
                if (null == this.classroomteachers)
                    this.classroomteachers = new List<ClassroomTeacher>();
                return this.classroomteachers;
            }
            set
            {
                this.classroomteachers = value;
            }
        }

        private IList<ClassroomStudent> classroomStudents;
        public virtual IList<ClassroomStudent> ClassroomStudents
        {
            get
            {
                if (null == this.classroomStudents)
                    this.classroomStudents = new List<ClassroomStudent>();
                return this.classroomStudents;
            }
            set
            {
                this.classroomStudents = value;
            }
        }

        #endregion persistent

    }
}
