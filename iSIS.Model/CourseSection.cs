using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class CourseSection : PersistentTemporalEntity32
    {
        #region persistent

        //public virtual long ID { get; set; }

        public virtual School School { get; set; }
   
        public virtual Course Course { get; set; }

        public virtual GradingSystem GradingSystem { get; set; }

        private Semester semester;
        public virtual Semester Semester
        {
            get { return this.semester; }
            set
            {
                this.School = value.School;
                this.semester = value;
            }
        }

        public virtual ClassLevelSection ClassLevelSection { get; set; }

        public virtual PhysicalRoom Room { get; set; }

        private IList<CourseSectionAppraisal> performanceIndicators;
        public virtual IList<CourseSectionAppraisal> Appraisals
        {
            get
            {
                if (null == this.performanceIndicators)
                    this.performanceIndicators = new List<CourseSectionAppraisal>();
                return this.performanceIndicators;
            }
            set
            {
                this.performanceIndicators = value;
            }
        }

        private IList<CourseSectionStudent> classSectionStudents;
        public virtual IList<CourseSectionStudent> CourseSectionStudents
        {
            get
            {
                if (null == this.classSectionStudents)
                    this.classSectionStudents = new List<CourseSectionStudent>();
                return this.classSectionStudents;
            }
            set
            {
                this.classSectionStudents = value;
            }
        }

        private IList<CourseSectionTeacher> classSectionTeachers;
        public virtual IList<CourseSectionTeacher> CourseSectionTeachers
        {
            get
            {
                if (null == this.classSectionTeachers)
                    this.classSectionTeachers = new List<CourseSectionTeacher>();
                return this.classSectionTeachers;
            }
            set
            {
                this.classSectionTeachers = value;
            }
        }

        #endregion persistent

    }
}
