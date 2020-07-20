using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Course : PersistentTemporalTitledEntity64
    {
        #region persistent

        public virtual Course Prerequisite { get; set; }
        public virtual ClassLevel Level { get; set; }
        public virtual int SemesterNo { get; set; }
        public virtual MultilingualString CourseNo { get; set; }
        public virtual MultilingualString Description { get; set; }
        public virtual float CreditHours { get; set; }
        public virtual Curriculum Curriculum { get; set; }
        public virtual OutcomeCategory OutcomeCategory { get; set; }
        public virtual School School { get; set; }
        public virtual GradingSystem GradingSystem { get; set; }
        public virtual int HoursPerSemester { get; set; } 

        #endregion persistent

        public override void Persist(SessionContext context)
        {
            if (null != CourseNo) CourseNo.Persist(context);
            if (null != Description) Description.Persist(context);
            base.Persist(context);
        }
    }
}
