using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class AuthorizeModule : PersistentTemporalEntity64
    {
        public virtual Organization Organization { get; set; }
        public virtual Role Role { get; set; }
        public virtual Module Module { get; set; }
    }
}
