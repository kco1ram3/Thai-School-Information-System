using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class RegisterDetail : PersonOrgRelationship
    {
        public virtual Register Registers { get; set; }
        public virtual Curriculum Curriculums { get; set; }
        public virtual Student Students { get; set; }
        public virtual Teacher Teachers { get; set; }
        public virtual string Status { get; set; }

        private IList<RegisterPayment> registerPayments;
        public virtual IList<RegisterPayment> RegisterPayments
        {
            get
            {
                if (null == this.registerPayments)
                    this.registerPayments = new List<RegisterPayment>();
                return this.registerPayments;
            }
            set
            {
                this.registerPayments = value;
            }
        }
    }
}
