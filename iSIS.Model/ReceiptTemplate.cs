using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class ReceiptTemplate : PersistentTemporalTitledEntity64
    {
        #region persistent

        public virtual School School { get; set; }
        public virtual string ReceiptNote { get; set; }
        public virtual decimal TotalAmount { get; set; }

        private IList<ReceiptTemplateItem> receiptTemplateItems;
        public virtual IList<ReceiptTemplateItem> ReceiptTemplateItems
        {
            get
            {
                if (null == this.receiptTemplateItems)
                    this.receiptTemplateItems = new List<ReceiptTemplateItem>();
                return this.receiptTemplateItems;
            }

            set
            {
                this.receiptTemplateItems = value;
            }
        }

        #endregion

        public virtual Receipt CreateNewReceipt()
        {
            Receipt receipt = new Receipt
            {
                Date = DateTime.Now,
                School = this.School,
                ReceiptItems = new List<ReceiptItem>(),
                TotalAmount = this.TotalAmount,
            };

            foreach (ReceiptTemplateItem i in this.ReceiptTemplateItems)
            {
                receipt.ReceiptItems.Add(new ReceiptItem(i));
            }

            return receipt;
        }

        public override void Persist(SessionContext context)
        {
            base.Persist(context);
            foreach (ReceiptTemplateItem i in this.ReceiptTemplateItems)
            {
                i.ReceiptTemplate = this;
                context.Persist(i);
            }
        }
    }
}
