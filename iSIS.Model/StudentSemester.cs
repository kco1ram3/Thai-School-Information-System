using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class StudentSemester : PersistentEntity64
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
        public virtual Semester Semester { get; set; }
        public virtual int BehavioralPoint { get; set; }
        public virtual int DeductedPoint { get; set; }
        public virtual float GPA { get; set; }

        #region Need mapping

        public virtual HierarchicalCategory Major { get; set; }

        #endregion

    }
}
