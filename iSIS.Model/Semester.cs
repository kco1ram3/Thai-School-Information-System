using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace iSISModel
{
    public class Semester : PersistentTemporalEntity64
    {
        #region persistent
        
        public virtual int AcademicYear { get; set; }
        public virtual int SemesterNo { get; set; }
        public virtual School School { get; set; }
        //public virtual TimeInterval PreregistrationPeriod { get; set; }
        //public virtual TimeInterval RegistrationPeriod { get; set; }
        //public virtual TimeInterval AddDropPeriod { get; set; }
        public virtual DateTimeRange ApplicationPeriod { get; set; }
        public virtual DateTimeRange FinalExamPeriod { get; set; }
        public virtual DateTimeRange TeachingPeriod { get; set; }


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

        private IList<ExamSchedule> examSchedules;
        public virtual IList<ExamSchedule> ExamSchedules
        {
            get
            {
                if (null == this.examSchedules)
                    this.examSchedules = new List<ExamSchedule>();
                return this.examSchedules;
            }

            set
            {
                this.examSchedules = value;
            }
        } 

        #endregion persistent

    }
}
