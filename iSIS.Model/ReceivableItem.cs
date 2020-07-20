using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class ReceivableItem : PersistentTemporalTitledEntity64
    {
        public virtual int SeqNo { get; set; }
        public virtual decimal DefaultAmount { get; set; }
        public virtual School School { get; set; }
    }
}
