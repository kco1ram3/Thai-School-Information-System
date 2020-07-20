using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Education : PersistentTemporalEntity64
    {
        public Education() { }
        public Education(long id)
        {
            this.ID = id;
        }

        public virtual Person Person { get; set; }
        public virtual HierarchicalCategory EducationLevel { get; set; }
        public virtual Organization AcademicInstitute { get; set; }

        public virtual string AcademicInstituteName { get; set; }
        public virtual string AcademicInstituteAddress { get; set; }
        public virtual string DegreeTitle { get; set; }
        public virtual string ShortDegreeTitle { get; set; }
    }
}
