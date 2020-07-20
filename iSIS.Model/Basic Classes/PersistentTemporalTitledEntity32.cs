using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public abstract class PersistentTemporalTitledEntity32 : PersistentTemporalEntity32
    {
        #region persistent

        public virtual MultilingualString Title { get; set; }
        public virtual MultilingualString ShortTitle { get; set; }

        #endregion

        public override void Persist(SessionContext context)
        {
            if (null != Title) Title.Persist(context);
            if (null != ShortTitle) ShortTitle.Persist(context);
            base.Persist(context);
        }
    }
}
