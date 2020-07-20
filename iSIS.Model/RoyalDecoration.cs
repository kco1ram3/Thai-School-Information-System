using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class RoyalDecoration : PersistentTemporalEntity64
    {
        public RoyalDecoration() { }
        public RoyalDecoration(long id)
        {
            this.ID = id;
        }

        public virtual Person Person { get; set; }
        public virtual HierarchicalCategory RoyalDecorationCategory { get; set; }
    }
}
