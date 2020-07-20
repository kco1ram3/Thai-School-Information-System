using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class AdmissionTest : PersistentEntity64
    {
        public virtual Admission Admission { get; set; }
        public virtual int SeqNo { get; set; }
        public virtual DateTimeRange TestPeriod { get; set; }
        public virtual MultilingualString Title { get; set; }
        public virtual MultilingualString Description { get; set; }
    }
}
