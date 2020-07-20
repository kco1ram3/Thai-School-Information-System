using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class CurriculumFramework : PersistentTemporalTitledEntity64
    {
        #region persistent
        
        private IList<DesiredOutcome> desiredOutcomes;
        public virtual IList<DesiredOutcome> DesiredOutcomes
        {
            get
            {
                if (null == this.desiredOutcomes)
                    this.desiredOutcomes = new List<DesiredOutcome>();
                return this.desiredOutcomes;
            }

            set
            {
                this.desiredOutcomes = value;
            }
        }

        #endregion

        public override void Persist(SessionContext context)
        {
            base.Persist(context);

            //foreach (Course s in this.Courses)
            //{
            //    //s.Curriculum = this;
            //    s.Persist(context);
            //}

            foreach (DesiredOutcome s in this.DesiredOutcomes)
            {
                s.CurriculumFramework = this;
                s.Parent = null;
                s.Persist(context);
            }
        }

        public static IList<CurriculumFramework> GetAll(SessionContext context)
        {
            return context.PersistenceSession.QueryOver<CurriculumFramework>().List();
        }

        public override string ToString()
        {
            return Code;
        }
    }
}
