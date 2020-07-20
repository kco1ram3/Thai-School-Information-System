using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Receipt : PersistentEntity64
    {
        #region persistent

        public virtual DateTime Date { get; set; }
        public virtual string ReceiptNo { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual string PayerName { get; set; }
        public virtual string PayerAddress { get; set; }
        public virtual School School { get; set; }
        public virtual Student Student { get; set; }
        public virtual decimal TotalAmount { get; set; }

        private IList<ReceiptItem> receiptItems;
        public virtual IList<ReceiptItem> ReceiptItems
        {
            get
            {
                if (null == this.receiptItems)
                    this.receiptItems = new List<ReceiptItem>();
                return this.receiptItems;
            }

            set
            {
                this.receiptItems = value;
            }
        }

        #endregion

        public override void Persist(SessionContext context)
        {
            base.Persist(context);
            foreach (ReceiptItem i in this.ReceiptItems)
            {
                i.Receipt = this;
                i.Persist(context);
            }
        } 
    }
}
