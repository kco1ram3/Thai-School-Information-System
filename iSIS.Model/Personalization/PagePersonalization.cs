using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel.Personalization
{
    public class PagePersonalization
    {
        public virtual int ID { get; set; }
        public virtual UserPersonalization UserPersonalization { get; set; }
        public virtual int PageID { get; set; }
        public virtual string PersonalizationXMLString { get; set; }

    }
}
