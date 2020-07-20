using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class AcademicEventParticipation : PersistentTemporalEntity64
    {
        public virtual Person Person { get; set; }
        public virtual HierarchicalCategory AcademicEventCategory { get; set; }
        public virtual string AcademicEventTitle { get; set; }
        public virtual string Venue { get; set; }
        public virtual string Description { get; set; }
    }
}
