using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Role : PersistentTemporalTitledEntity64
    {
        public virtual Application Application { get; set; }
        public virtual MultilingualString Description { get; set; }
    }
}
