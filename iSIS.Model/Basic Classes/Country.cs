using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Country 
    {
        public virtual string Code { get; set; }
        public virtual string Alpha2Code { get; set; }
        public virtual string Alpha3Code { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual MultilingualString Title { get; set; }

        public virtual void Persist(SessionContext context)
        {
            if (null != Title)
                Title.Persist(context);
            context.Persist(this);
        }

        private IList<GeographicRegion> firstLevelRegions;
        public virtual IList<GeographicRegion> FirstLevelRegions
        {
            get
            {
                if (null == this.firstLevelRegions)
                    this.firstLevelRegions = new List<GeographicRegion>();
                return this.firstLevelRegions;
            }
            set
            {
                this.firstLevelRegions = value;
            }
        }
    }
}
