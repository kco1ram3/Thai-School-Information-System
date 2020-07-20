using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class OrgName : PersistentTemporalTitledEntity64
    {
        public virtual Organization Organization { get; set; }

        public override string ToString()
        {
            if (null == Title)
                if (null == ShortTitle)
                    return "";
                else
                    return ShortTitle.ToString();
            else
                return Title.ToString();
        }

        public virtual string ToString(string languageCode)
        {
            if (null == Title)
                if (null == ShortTitle)
                    return "";
                else
                    return ShortTitle.ToString(languageCode);
            else
                return Title.ToString(languageCode);
        }
    }
}
