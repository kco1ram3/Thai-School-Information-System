using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class CourseSectionAppraisal : PersistentTemporalEntity32
    {
        public CourseSectionAppraisal() {}
        public CourseSectionAppraisal(CourseSection courseSection)
        {
            this.CourseSection = courseSection;
        }

        public virtual int SeqNo { get; set; }
        public virtual MultilingualString Title { get; set; }
        public virtual MultilingualString Description { get; set; }
        [UIHint("DateNullable"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime AppraisalDate { get; set; }
        public virtual float PerfectScore { get; set; }
        public virtual float AverageScore { get; set; }
        public virtual float MaxScore { get; set; }
        public virtual float MinScore { get; set; }
        public virtual CourseSection CourseSection { get; set; }
    }
}
