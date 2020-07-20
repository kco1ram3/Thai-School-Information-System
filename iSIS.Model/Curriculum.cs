using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Curriculum : PersistentTemporalTitledEntity64
    {
        #region persistent

        public virtual CurriculumFramework CurriculumFramework { get; set; }
        public virtual School School { get; set; }
        public virtual ClassLevel StartingClassLevel { get; set; }
        public virtual ClassLevel EndingClassLevel { get; set; }
        public virtual MultilingualString Description { get; set; }

        private IList<CurriculumCourse> curriculumCourses;
        public virtual IList<CurriculumCourse> CurriculumCourses
        {
            get
            {
                if (null == this.curriculumCourses)
                    this.curriculumCourses = new List<CurriculumCourse>();
                return this.curriculumCourses;
            }
            set
            {
                this.curriculumCourses = value;
            }
        } 
        
        #endregion

        public virtual IList<CurriculumCourse> GetCourses(HierarchicalCategory ofCategory)
        {
            IList<CurriculumCourse> courses = new List<CurriculumCourse>();
            foreach (CurriculumCourse c in this.CurriculumCourses)
            {
                if (c.Category == ofCategory)
                    courses.Add(c);
            }
            return courses;
        }

    }
}
