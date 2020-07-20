using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace iSISModel
{
    public class DiscreteGradingSystem : GradingSystem 
    {
        #region persistent

        private IList<DiscreteGrade> grades;
        public virtual IList<DiscreteGrade> Grades
        {
            get
            {
                if (null == this.grades)
                    this.grades = new List<DiscreteGrade>();
                return this.grades;
            }
            set
            {
                this.grades = value;
            }
        }

        #endregion
        
        public override void Persist(SessionContext context)
        {
            base.Persist(context);
            foreach (DiscreteGrade g in this.Grades)
            {
                g.GradingSystem = this;
                context.Persist(g);
            }
        }
    }
}
