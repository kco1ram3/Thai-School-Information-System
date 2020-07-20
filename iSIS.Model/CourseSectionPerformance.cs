using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class CourseSectionPerformance : PersistentEntity64
    {
        public virtual CourseSectionAppraisal CourseSectionAppraisal { get; set; }
        public virtual CourseSectionStudent CourseSectionStudent { get; set; }
        public virtual DateTime AppraisalDate { get; set; }
        public virtual float Score { get; set; }
    }
}
