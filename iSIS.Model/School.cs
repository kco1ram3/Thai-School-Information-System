using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iSISModel.Accounting;

namespace iSISModel
{
    public class School : Organization
    {
        #region persistent

        /// <summary>
        /// สังกัด
        /// </summary>
        public virtual HierarchicalCategory SupervisoryOrganization { get; set; }

        private IList<Curriculum> curriculums;
        public virtual IList<Curriculum> Curriculums
        {
            get
            {
                if (null == this.curriculums)
                    this.curriculums = new List<Curriculum>();
                return this.curriculums.Where(c => c.IsEffectiveNow).ToList();
            }
            set
            {
                this.curriculums = value;
            }
        }

        private IList<Admission> admissions;
        public virtual IList<Admission> Admissions
        {
            get
            {
                if (null == this.admissions)
                    this.admissions = new List<Admission>();
                return this.admissions.Where(a => a.ApplyPeriod.To > DateTime.Today).ToList();
            }
            set
            {
                this.admissions = value;
            }
        }

        private IList<SchoolOutcomeCategoryGrading> schoolOutcomeCategoryGradings;
        public virtual IList<SchoolOutcomeCategoryGrading> SchoolOutcomeCategoryGradings
        {
            get
            {
                if (null == this.schoolOutcomeCategoryGradings)
                    this.schoolOutcomeCategoryGradings = new List<SchoolOutcomeCategoryGrading>();
                return this.schoolOutcomeCategoryGradings;
            }

            set
            {
                this.schoolOutcomeCategoryGradings = value;
            }
        }

        private IList<ClassLevelSection> classLevelSections;
        public virtual IList<ClassLevelSection> ClassLevelSections
        {
            get
            {
                if (null == this.classLevelSections)
                    this.classLevelSections = new List<ClassLevelSection>();
                return this.classLevelSections;
            }

            set
            {
                this.classLevelSections = value;
            }
        }

        private IList<ReceivableItem> receivableItems;
        public virtual IList<ReceivableItem> ReceivableItems
        {
            get
            {
                if (null == this.receivableItems)
                    this.receivableItems = new List<ReceivableItem>();
                return this.receivableItems;
            }
            set
            {
                this.receivableItems = value;
            }
        }

        private IList<ReceiptTemplate> receiptTemplates;
        public virtual IList<ReceiptTemplate> ReceiptTemplates
        {
            get
            {
                if (null == this.receiptTemplates)
                    this.receiptTemplates = new List<ReceiptTemplate>();
                return this.receiptTemplates;
            }
            set
            {
                this.receiptTemplates = value;
            }
        }

        private IList<PhysicalRoom> rooms;
        public virtual IList<PhysicalRoom> Rooms
        {
            get
            {
                if (null == this.rooms)
                    this.rooms = new List<PhysicalRoom>();
                return this.rooms;
            }
            set
            {
                this.rooms = value;
            }
        }

        private IList<Semester> semesters;
        public virtual IList<Semester> Semesters
        {
            get
            {
                if (null == this.semesters)
                    this.semesters = new List<Semester>();
                return this.semesters.Where(s => s.IsEffectiveNow).OrderBy(s => s.AcademicYear).ToList();
            }
            set
            {
                this.semesters = value;
            }
        }

        private IList<Course> courses;
        public virtual IList<Course> Courses
        {
            get
            {
                if (null == this.courses)
                    this.courses = new List<Course>();
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        }

        public virtual ClassLevel MaxClassLevel { get; set; }

        public virtual ClassLevel MinClassLevel { get; set; }

        #endregion persistent

        private Semester currentSemester;
        public virtual Semester CurrentSemester
        {
            get
            {
                if (null == this.currentSemester && this.Semesters.Count > 0)
                {
                    foreach (Semester s in this.Semesters)
                    {
                        if (s.IsEffectiveNow)
                        {
                            this.currentSemester = s;
                            break;
                        }
                    }
                }
                return this.currentSemester;
            }
            set
            {
                if (null != value)
                {
                    //Check for duplicate
                    foreach (Semester s in this.Semesters)
                        if (value.SemesterNo == s.SemesterNo && value.AcademicYear == s.AcademicYear)
                            throw new Exception("Duplicate semester.");
                    this.Semesters.Add(value);
                }
                if (value.IsEffectiveNow)
                    this.currentSemester = value;
            }
        }

        public virtual Semester GetSemester(SessionContext context, int semesterNo, int academicYear)
        {
            return context.PersistenceSession.QueryOver<Semester>()
                .Where(s => s.School == this && s.AcademicYear == academicYear && s.SemesterNo == semesterNo)
                .SingleOrDefault();
        }

        public virtual Student GetStudentByID(SessionContext context, string idNo)
        {
            return context.PersistenceSession.QueryOver<Student>()
                .Where(s => s.School == this && s.IDNo == idNo)
                .SingleOrDefault();
        }

        public override void Persist(SessionContext context)
        {
            base.Persist(context);
            foreach (ReceivableItem i in ReceivableItems)
            {
                i.School = this;
                i.Persist(context);
            }
            foreach (ReceiptTemplate i in ReceiptTemplates)
            {
                i.School = this;
                i.Persist(context);
            }
            foreach (ClassLevelSection i in ClassLevelSections)
            {
                i.School = this;
                i.Persist(context);
            }
            foreach (Course i in Courses)
            {
                i.School = this;
                i.Persist(context);
            }
            foreach (PhysicalRoom i in Rooms)
            {
                i.School = this;
                i.Persist(context);
            }
            foreach (SchoolOutcomeCategoryGrading i in SchoolOutcomeCategoryGradings)
            {
                i.School = this;
                i.Persist(context);
            }
            //foreach ( i in s)
            //{
            //    i.School = this;
            //    i.Persist(context);
            //}
        }
    }
}
