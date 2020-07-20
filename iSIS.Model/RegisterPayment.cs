using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class RegisterPayment : PersistentTemporalEntity64
    {
        public virtual RegisterDetail RegisterDetails { get; set; }
        public virtual Course Courses { get; set; }
        public virtual User Users { get; set; }
        public virtual double Price { get; set; }
        public virtual int Unit { get; set; }
        public virtual DateTime Create_Date { get; set; }
        public virtual DateTime Update_Date { get; set; }
    }
}
