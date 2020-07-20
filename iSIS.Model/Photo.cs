using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Photo : PersistentEntity64
    {
        public virtual Person Person { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual byte[] Image { get; set; }
    }
}
