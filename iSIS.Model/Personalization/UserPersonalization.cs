using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel.Personalization
{
    public class UserPersonalization
    {
        public virtual int ID { get; set; }
        public virtual User User { get; set; }
        public virtual string Language { get; set; }
        public virtual string ThemeName { get; set; }

        private IList<PagePersonalization> pagePersonalizations;
        public virtual IList<PagePersonalization> PagePersonalizations
        {
            get
            {
                if (null == this.pagePersonalizations)
                    this.pagePersonalizations = new List<PagePersonalization>();
                return this.pagePersonalizations;
            }

            set
            {
                this.pagePersonalizations = value;
            }
        }
    }
}
