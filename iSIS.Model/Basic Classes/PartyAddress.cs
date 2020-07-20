using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    [Serializable]
    public class PartyAddress : PersistentTemporalEntity32, ICategorizedTemporal
    {
        #region persistent
        
        public virtual HierarchicalCategory Category { get; set; } 
        public virtual Party Party { get; set; }
        public virtual GeographicAddress Address { get; set; }

        #endregion persistent

        public override void Persist(SessionContext context)
        {
            if (this.Address != null)
            {
                Address.Persist(context);
            }
            base.Persist(context);
        }

        public override string ToString()
        {
            if (null != this.Address)
                return this.Category.Title.ToString() + ": " + this.Address.ToString();
            else
                return this.Category.Title.ToString() + ": N/A";
        }

        public virtual string ToString(string languageCode)
        {
            if (null != this.Address)
                return this.Category.Title.ToString(languageCode) + ": " + this.Address.ToString(languageCode);
            else
                return this.Category.Title.ToString(languageCode) + ": N/A";
        }
    }
}
