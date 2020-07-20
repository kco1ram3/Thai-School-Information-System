using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class StudentAcademicYear : PersistentEntity64
    {
        public virtual ClassLevel ClassLevel { get; set; }
        public virtual School School
        {
            get
            {
                if (null == this.Student)
                    return null;
                return this.Student.School;
            }
            set { }
        }
        public virtual Student Student { get; set; }
        public virtual int AcademicYear { get; set; }

        public virtual int BehavioralPoint { get; set; }
        public virtual int DeductedPoint { get; set; }
        public virtual float Semester1GPA { get; set; }
        public virtual float Semester2GPA { get; set; }
        public virtual float GPA { get; set; }
    }
}
