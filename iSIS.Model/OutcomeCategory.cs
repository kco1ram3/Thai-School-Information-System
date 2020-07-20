using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class OutcomeCategory : DesiredOutcome
    {
        #region persistent

        public virtual DiscreteGradingSystem DefaultGradingSystem { get; set; }

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

        private IList<Course> courses;
        public virtual IList<Course> Courses
        {
            get
            {
                if (null == this.courses)
                    this.courses = new List<Course>();
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        }

        #endregion

        public OutcomeCategory()
        {
        }

        public OutcomeCategory(long ID)
        {
            this.ID = ID;
        }

        public override void Persist(SessionContext context)
        {
            base.Persist(context);

            foreach (Course s in this.Courses)
            {
                s.OutcomeCategory = this;
                s.Persist(context);
            }

            foreach (DesiredOutcome s in this.DesiredOutcomes)
            {
                s.CurriculumFramework = this.CurriculumFramework;
                s.Parent = this;
                s.Persist(context);
            }
        }

        public override string ToString()
        {
            return base.ID.ToString() + "-" + base.Code;
        }

    }
}
