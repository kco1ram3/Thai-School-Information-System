using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Admission : PersistentEntity64
    {
        public virtual new int ID { get; set; }
        public virtual int SeqNo { get; set; }
        public virtual School School { get; set; }
        //public virtual ClassLevel AdmittedClassLevel { get; set; }

        public virtual MultilingualString Description { get; set; }


        //public virtual DateTime TestResultPublishDate { get; set; }
        public virtual ReceiptTemplate ApplicationReceiptTemplate { get; set; }
        public virtual ReceiptTemplate RegistrationReceiptTemplate { get; set; }

        /// <summary>
        /// ช่วงวันสมัคร
        /// </summary>
        public virtual DateTimeRange ApplyPeriod { get; set; }
        public virtual string ApplicationFormURL { get; set; }
        //public virtual string ApplicationInfoURL { get; set; }

        ///// <summary>
        ///// ช่วงวันมอบตัว
        ///// </summary>
        //public virtual DateTimeRange RegistrationPeriod { get; set; }
        //public virtual string RegistrationFormURL { get; set; }
        //public virtual string RegistrationInfoURL { get; set; }

        private Semester startSemester;
        public virtual Semester StartSemester
        {
            get
            {
                return this.startSemester;
            }
            set
            {
                if (null != value && value.SemesterNo != 1)
                    throw new Exception();
                this.startSemester = value;
            }
        }

        private IList<AdmissionTestRoom> admissionTestRooms;
        public virtual IList<AdmissionTestRoom> AdmissionTestRooms
        {
            get
            {
                if (null == admissionTestRooms)
                    admissionTestRooms = new List<AdmissionTestRoom>();
                return admissionTestRooms;
            }
            set
            {
                admissionTestRooms = value;
            }
        }

        private IList<AdmitCurriculum> admitCurriculums;
        public virtual IList<AdmitCurriculum> AdmitCurriculums
        {
            get
            {
                if (null == admitCurriculums)
                    admitCurriculums = new List<AdmitCurriculum>();
                return admitCurriculums;
            }
            set
            {
                admitCurriculums = value;
            }
        }

        private IList<AdmissionTest> admissionTests;
        public virtual IList<AdmissionTest> AdmissionTests
        {
            get
            {
                if (null == admissionTests)
                    admissionTests = new List<AdmissionTest>();
                return admissionTests;
            }
            set
            {
                admissionTests = value;
            }
        }

        private IList<StudentApplication> studentApplications;
        public virtual IList<StudentApplication> StudentApplications
        {
            get
            {
                if (null == studentApplications)
                    studentApplications = new List<StudentApplication>();
                return studentApplications;
            }
            set
            {
                studentApplications = value;
            }
        }

        //AB
        public override void Persist(SessionContext context)
        {
            base.Persist(context);

        

            foreach (AdmissionTestRoom i in this.AdmissionTestRooms)
            {
                i.Admission = this;
                i.Persist(context);
            }

            foreach (AdmitCurriculum i in this.AdmitCurriculums)
            {
                i.Admission = this;
                i.Persist(context);
            }

            foreach (AdmissionTest i in this.AdmissionTests)
            {
                i.Admission = this;
                i.Persist(context);
            }

            foreach (StudentApplication i in this.StudentApplications)
            {
                i.Admission = this;
                i.Persist(context);
            }
        }
    }
}
