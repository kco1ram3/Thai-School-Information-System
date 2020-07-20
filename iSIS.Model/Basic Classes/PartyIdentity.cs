using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    [Serializable]
    public class PartyIdentity : PersistentTemporalEntity64, ICategorizedTemporal
    {
        public virtual HierarchicalCategory Category { get; set; }
        public virtual Organization IssuedBy { get; set; }
        public virtual Party Party { get; set; }
        public virtual string IDNo { get; set; }
    }
}
