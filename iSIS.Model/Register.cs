using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Register : PersonOrgRelationship
    {
        public virtual Semester Semesters { get; set; }        
        public virtual User Users { get; set; }
        public virtual int Subject_Amount { get; set; }
        public virtual DateTime Create_Date { get; set; }
        public virtual DateTime Update_Date { get; set; }

        public virtual School Schools
        {
            get { return (School)base.Organization; }
            set { base.Organization = value; }
        }

        private IList<RegisterDetail> registerDetails;
        public virtual IList<RegisterDetail> RegisterDetails
        {
            get
            {
                if (null == this.registerDetails)
                    this.registerDetails = new List<RegisterDetail>();
                return this.registerDetails;
            }
            set
            {
                this.registerDetails = value;
            }
        }
    }
}
