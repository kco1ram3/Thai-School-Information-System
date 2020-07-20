using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace iSISModel
{
    public class Student : PersonOrgRelationship
    {
        #region persistent

        //public virtual float GPA { get; set; }
        public virtual float AdmittedGPA { get; set; }
        public virtual float CurrentGPA { get; set; }
        public virtual ClassLevel AdmittedClassLevel { get; set; }
        public virtual int AdmittedAcademicYear { get; set; }
        public virtual Semester AdmittedSemester { get; set; }
        public virtual int AdmittedSemesterNo { get; set; }
        public virtual Curriculum Curriculum  { get; set; }
        public virtual HierarchicalCategory Major { get; set; }
        public virtual HierarchicalCategory Status { get; set; }

        public virtual School School
        {
            get { return (School)base.Organization; }
            set { base.Organization = value; }
        }

        private IList<Absence> absences;
        public virtual IList<Absence> Absences
        {
            get
            {
                if (null == this.absences)
                    this.absences = new List<Absence>();
                return this.absences;
            }
            set
            {
                this.absences = value;
            }
        }

        private IList<Punishment> punishments;
        public virtual IList<Punishment> Punishments
        {
            get
            {
                if (null == this.punishments)
                    this.punishments = new List<Punishment>();
                return this.punishments;
            }
            set
            {
                this.punishments = value;
            }
        }

        private IList<Reward> rewards;
        public virtual IList<Reward> Rewards
        {
            get
            {
                if (null == this.rewards)
                    this.rewards = new List<Reward>();
                return this.rewards;
            }
            set
            {
                this.rewards = value;
            }
        }

        private IList<StudentAcademicYear> studentAcademicYears;
        public virtual IList<StudentAcademicYear> StudentAcademicYears
        {
            get
            {
                if (null == this.studentAcademicYears)
                    this.studentAcademicYears = new List<StudentAcademicYear>();
                return this.studentAcademicYears;
            }
            set
            {
                this.studentAcademicYears = value;
            }
        }

        private IList<StudentSemester> studentSemesters;
        public virtual IList<StudentSemester> StudentSemesters
        {
            get
            {
                if (null == this.studentSemesters)
                    this.studentSemesters = new List<StudentSemester>();
                return this.studentSemesters;
            }
            set
            {
                this.studentSemesters = value;
            }
        }

        //private IList<X> x;
        //public virtual IList<X> Xs
        //{
        //    get
        //    {
        //        if (null == this.x)
        //            this.x = new List<X>();
        //        return this.x;
        //    }
        //    set
        //    {
        //        this.x = value;
        //    }
        //}

        private IList<ClassroomStudent> classroomStudents;
        public virtual IList<ClassroomStudent> ClassroomStudents
        {
            get
            {
                if (null == this.classroomStudents)
                    this.classroomStudents = new List<ClassroomStudent>();
                return this.classroomStudents;
            }
            set
            {
                this.classroomStudents = value;
            }
        }

        private IList<CourseSectionStudent> courseSectionStudents;
        public virtual IList<CourseSectionStudent> CourseSectionStudents
        {
            get
            {
                if (null == this.courseSectionStudents)
                    this.courseSectionStudents = new List<CourseSectionStudent>();
                return this.courseSectionStudents;
            }

            set
            {
                this.courseSectionStudents = value;
            }
        }

        private IList<PerformanceMeasurement> performanceMeasurements;
        public virtual IList<PerformanceMeasurement> PerformanceMeasurements
        {
            get
            {
                if (null == this.performanceMeasurements)
                    this.performanceMeasurements = new List<PerformanceMeasurement>();
                return this.performanceMeasurements;
            }
            set
            {
                this.performanceMeasurements = value;
            }
        }

        #endregion persistent

        public static IList<Student> Get(SessionContext context, School schools, string idNo)
        {
            return context.PersistenceSession.QueryOver<Student>()
                .Where(s => s.School == schools && s.IDNo == idNo)
                .List();
        }
    }
}
