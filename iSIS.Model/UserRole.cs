﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class UserRole : PersistentTemporalEntity64
    {
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
