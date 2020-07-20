using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSIS.Models
{
    public class ComboBoxItems
    {
        public virtual string Text { get; set; }
        public virtual string Value { get; set; }

        public ComboBoxItems(string Text, string Value)
        {
            this.Text = Text;
            this.Value = Value;
        }
    }
}