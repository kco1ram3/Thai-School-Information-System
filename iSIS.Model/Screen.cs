using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Screen : PersistentTemporalTitledEntity64
    {
        public virtual Module Module { get; set; }
        public virtual Screen Parent { get; set; }

        private IList<Screen> children;
        public virtual IList<Screen> Children
        {
            get
            {
                if (null == this.children)
                    this.children = new List<Screen>();
                return this.children;
            }
            set
            {
                this.children = value;
            }
        }

        public virtual string NavigateUrl { get; set; }
        public virtual int SeqNo { get; set; }
        public override void Persist(SessionContext context)
        {
            base.Persist(context);
            try
            {
                foreach (Screen child in this.Children)
                {
                    child.Parent = this;
                    child.Persist(context);
                    SaveChildren(context, child, child.Children);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void SaveChildren(SessionContext context, Screen parent, IList<Screen> children)
        {
            foreach (Screen child in children)
            {
                child.Parent = parent;
                child.Persist(context);
                SaveChildren(context, child, child.Children);
            }
        }
    }
}
