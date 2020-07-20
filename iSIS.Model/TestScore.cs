using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class TestScore
    {
        public virtual long ID { get; set; }

        public virtual float Score { get; set; }
        public virtual string Remark { get; set; }
        public virtual StudentApplication StudentApplication { get; set; }
        public virtual AdmissionTest AdmissionTest { get; set; }
    }
}
