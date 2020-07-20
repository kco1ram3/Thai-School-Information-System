using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class PhysicalRoom : PersistentTemporalEntity64
    {
        public virtual School School { get; set; }
        public virtual ClassLevel ClassLevel { get; set; }
        public virtual MultilingualString BuildingTitle { get; set; }
        public virtual string RoomNo { get; set; }
    }
}
