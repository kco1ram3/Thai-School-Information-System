using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Experience : PersistentTemporalEntity64
    {
        public virtual Person Person { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual string OrganizationName { get; set; }
        public virtual string OrganizationAddress { get; set; }
        public virtual string JobDescription { get; set; }
    }
}
