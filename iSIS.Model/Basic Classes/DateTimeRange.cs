using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class DateTimeRange
    {
        public static readonly DateTimeRange Never = new DateTimeRange(MaxDate, MinDate);
        public static readonly DateTimeRange Forever = new DateTimeRange(MinDate, MaxDate);
        public static readonly DateTime MinDate = new DateTime(2400, 1, 1);
        public static readonly DateTime MaxDate = new DateTime(2700, 12, 31);

        public virtual DateTime EffectiveDate
        {
            get { return this.From; }
            set { this.From = value; }
        }
        
        public virtual DateTime ExpiryDate
        {
            get { return this.To.AddDays(1); }
            set { this.To = value.AddDays(-1); }
        }

        #region persistent

        [UIHint("DateNullable"), DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public virtual DateTime From { get; set; }
        [UIHint("DateNullable"), DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public virtual DateTime To { get; set; }

        #endregion
        
        public DateTimeRange()
        {
            this.To = MinDate;
            this.From = MaxDate;
        }

        public DateTimeRange(DateTime from)
        {
            this.From = from;
            this.To = MaxDate;
        }

        public DateTimeRange(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }

        public virtual bool IsEffectiveNow()
        {
            DateTime now = DateTime.Now;
            return this.From <= now && now <= this.To;
        }

        public virtual bool IsEffectiveOn(DateTime dateTime)
        {
            return dateTime != MinDate
                && dateTime != MaxDate
                && this.From <= dateTime
                && dateTime <= this.To;
        }

        public override string ToString()
        {
            return this.From.ToShortDateString()
                + "-"
                + ((this.To == MaxDate) ? "[N/A]" : this.To.ToShortDateString());
        }

        public void Expire(DateTime expiryDate)
        {
            this.ExpiryDate = expiryDate;
        }

        public bool IsEmpty
        {
            get
            {
                return this.From >= this.To;
            }
        }
    }
}
