using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class AdmissionTestRoom : PersistentEntity32
    {
        public virtual int Capacity { get; set; }
        public virtual PhysicalRoom PhysicalRoom { get; set; }
        public virtual Admission Admission { get; set; }
    }
}
