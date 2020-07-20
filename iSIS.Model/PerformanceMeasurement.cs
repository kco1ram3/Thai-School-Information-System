using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class PerformanceMeasurement : PersistentTemporalEntity64
    {
        //public virtual int ID { get; set; }

        public virtual Student Student { get; set; }

        public virtual float Point { get; set; }

        public virtual DiscreteGrade Grade { get; set; }

        public virtual int SequenceNo { get; set; }

        private CourseSection courseSection;
        public virtual CourseSection CourseSection
        {
            get { return this.courseSection; }
            set
            {
                if (null != value)
                    this.Semester = value.Semester;
                this.courseSection = value;
            }
        }

        public virtual Semester Semester { get; set; }

        public virtual PerformanceIndicator PerformanceIndicator { get; set; }

    }
}
