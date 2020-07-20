using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class ReceiptItem : PersistentEntity64
    {
        public ReceiptItem()
        {
        }
        
        public ReceiptItem(ReceiptTemplateItem i)
        {
            this.ReceivableItem = i.ReceivableItem;
            this.Amount = i.DefaultAmount;
            this.AmountPerUnit = i.DefaultAmountPerUnit;
            this.Units = i.DefaultUnits;
            this.SeqNo = i.SeqNo;
        }

        #region persistent

        public virtual int SeqNo { get; set; }
        public virtual decimal AmountPerUnit { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual int Units { get; set; }
        public virtual Receipt Receipt { get; set; }
        public virtual ReceivableItem ReceivableItem { get; set; }

        #endregion
    }
}
