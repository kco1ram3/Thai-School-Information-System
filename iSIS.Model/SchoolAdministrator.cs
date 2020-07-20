using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class SchoolAdministrator : PersonOrgRelationship
    {
        public SchoolAdministrator()
        {
        }

        public SchoolAdministrator(Person administrator, School school, HierarchicalCategory position, DateTime effectiveDate)
        {
            this.Person = administrator;
            this.School = school;
            this.Category = position;
            this.EffectivePeriod = new DateTimeRange(effectiveDate);
        }
        
        #region persistent

        public virtual new int ID { get; set; } 
        //public virtual int StartAcademicYear { get; set; }
        //public virtual int StartSemesterNo { get; set; }
        //public virtual Semester StartSemester { get; set; }
        public virtual HierarchicalCategory Status { get; set; }

        public virtual School School
        {
            get { return (School)base.Organization; }
            set { base.Organization = value; }
        }

        #endregion
    }
}
