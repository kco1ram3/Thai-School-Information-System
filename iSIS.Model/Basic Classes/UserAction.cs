using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class UserAction
    {
        public virtual User User { get; set; }
        public virtual DateTime ActionTS { get; set; }
        public virtual String Remark { get; set; }

    }
}
