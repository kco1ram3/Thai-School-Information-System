using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public abstract class DesiredOutcome : PersistentTemporalTitledEntity64
    {
        #region persistent
        public virtual OutcomeCategory OutcomeCategory { get; set; }
        public virtual CurriculumFramework CurriculumFramework { get; set; }
        public virtual int SequenceNo { get; set; }
        public virtual string Description { get; set; }
        public virtual OutcomeCategory Parent { get; set; }

        #endregion


    }
}
