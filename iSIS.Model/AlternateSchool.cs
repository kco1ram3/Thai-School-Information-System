using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class AlternateSchool : PersistentEntity64
    {
        public virtual int Rank { get; set; }
        public virtual School School { get; set; }
        public virtual StudentApplication StudentApplication { get; set; }

    }
}
