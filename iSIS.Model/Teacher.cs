using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Teacher : PersonOrgRelationship
    {
        public Teacher()
        {
        }

        public Teacher(Person teacher, School school, DateTime effectiveDate)
        {
            this.Person = teacher;
            this.School = school;
            this.EffectivePeriod = new DateTimeRange(effectiveDate);
        }

        #region persistent

        public virtual int StartAcademicYear { get; set; }
        public virtual int StartSemesterNo { get; set; }
        public virtual Semester StartSemester { get; set; }
        public virtual HierarchicalCategory Status { get; set; }

        private IList<ClassroomTeacher> classes;
        public virtual IList<ClassroomTeacher> ClassroomTeachers
        {
            get
            {
                if (null == this.classes)
                    this.classes = new List<ClassroomTeacher>();
                return this.classes;
            }
            set
            {
                this.classes = value;
            }
        }

        private IList<CourseSectionTeacher> courseSectionTeachers;
        public virtual IList<CourseSectionTeacher> CourseSectionTeachers
        {
            get
            {
                if (null == this.courseSectionTeachers)
                    this.courseSectionTeachers = new List<CourseSectionTeacher>();
                return this.courseSectionTeachers;
            }
            set
            {
                this.courseSectionTeachers = value;
            }
        }

        public virtual School School
        {
            get { return (School)base.Organization; }
            set { base.Organization = value; }
        }

        #endregion persistent

        public virtual IList<ClassroomTeacher> GetClassrooms(SessionContext context, Semester semester)
        {
            IList<ClassroomTeacher> classrooms = context.PersistenceSession.QueryOver<ClassroomTeacher>()
                                                        .Where(c => c.Teacher == this
                                                                && c.EffectivePeriod.From <= semester.EffectivePeriod.From
                                                                && semester.EffectivePeriod.From <= c.EffectivePeriod.To)
                                                        .List();
            return classrooms;
        }

        public static Teacher GetTeacher(SessionContext context, Person person, School school, Semester semester)
        {
            Teacher teacher = context.PersistenceSession.QueryOver<Teacher>()
                                    .Where(t => t.Person == person && t.School == school
                                            && t.EffectivePeriod.From <= semester.EffectivePeriod.From
                                            && semester.EffectivePeriod.From <= t.EffectivePeriod.To)
                                    .SingleOrDefault();
            return teacher;
        }
    }
}
