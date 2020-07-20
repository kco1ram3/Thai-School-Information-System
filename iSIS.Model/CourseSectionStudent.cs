using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class CourseSectionStudent : PersistentTemporalEntity64
    {
        public virtual CourseSection CourseSection { get; set; }
        public virtual Student Student { get; set; }
        public virtual int AttendedHours { get; set; }
        public virtual float TotalScore { get; set; }

        private DiscreteGrade grade;
        public virtual DiscreteGrade Grade
        {
            get { return this.grade; }
            set
            {
                if (null != value)
                    this.GradePoint = value.Point;
                this.grade = value;
            }
        }

        public virtual float GradePoint { get; set; }

        private IList<CourseSectionPerformance> performances;
        public virtual IList<CourseSectionPerformance> Performances
        {
            get
            {
                if (null == this.performances)
                    this.performances = new List<CourseSectionPerformance>();
                return this.performances;
            }
            set
            {
                this.performances = value;
            }
        }
        
    }
}
