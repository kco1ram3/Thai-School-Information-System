using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class ReceiptTemplateItem : PersistentEntity64
    {
        public virtual int SeqNo { get; set; }

        public virtual ReceiptTemplate ReceiptTemplate { get; set; }

        public virtual ReceivableItem ReceivableItem { get; set; }

        public virtual decimal DefaultAmount { get; set; }

        public virtual decimal DefaultAmountPerUnit { get; set; }

        public virtual int DefaultUnits { get; set; }
    }
}
