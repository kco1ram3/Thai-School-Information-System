using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class StudentApplication : PersistentEntity64
    {
        public virtual string IDNo { get; set; }
        public virtual Curriculum AppliedCurriculum { get; set; }
        public virtual DateTime AppliedDate { get; set; }
        public virtual Person Applicant { get; set; }
        public virtual PersonName FatherName { get; set; }
        public virtual PersonName MotherName { get; set; }
        public virtual Person Father { get; set; }
        public virtual Person Mother { get; set; }
        public virtual Person Guardian { get; set; }
        public virtual IList<AlternateSchool> AlternateSchools { get; set; }

        public virtual School LastSchool { get; set; }
        public virtual ClassLevel LastClassLevel { get; set; }
        public virtual float GPA { get; set; }

        public virtual float ONETScore { get; set; }

        public virtual int IsAdmitted { get; set; }
        public virtual int Rank { get; set; }
        public virtual float TotalTestScore { get; set; }

        

        private IList<TestScore> testScores;
        public virtual IList<TestScore> TestScores
        {
            get
            {
                if (null == testScores)
                    testScores = new List<TestScore>();
                return testScores;
            }
            set
            {
                testScores = value;
            }
        }

        public virtual Admission Admission { get; set; }
        public virtual AdmissionTestRoom TestRoom { get; set; }
    }
}
