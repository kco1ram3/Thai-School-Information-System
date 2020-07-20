using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class GeographicRegion : PersistentTemporalEntity64
    {
        public virtual Country Country { get; set; }
        public virtual MultilingualString Title { get; set; }
        public virtual GeographicRegion Parent { get; set; }

        private IList<GeographicRegion> subregions;
        public virtual IList<GeographicRegion> Subregions
        {
            get
            {
                if (null == this.subregions)
                    this.subregions = new List<GeographicRegion>();
                return this.subregions;
            }

            set
            {
                this.subregions = value;
            }
        }

        public override void Persist(SessionContext context)
        {
            base.Persist(context);
            foreach (GeographicRegion r in Subregions)
            {
                r.Parent = this;
                r.Persist(context);
            }
        }

        public override string ToString()
        {
            if (null == Title)
                return "";
            else
                return Title.ToString();
        }

        public virtual string ToString(string languageCode)
        {
            if (null == Title)
                return "";
            else
                return Title.ToString(languageCode);
        }
    }
}
