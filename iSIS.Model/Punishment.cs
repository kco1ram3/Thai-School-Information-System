using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Punishment : PersistentTemporalEntity64
    {
        public virtual int DeductedPoint { get; set; }

        public virtual Student Student { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual HierarchicalCategory WrongDoingCategory { get; set; }

        public virtual HierarchicalCategory PunishmentCategory { get; set; }

        public virtual string Description { get; set; }

    }
}
