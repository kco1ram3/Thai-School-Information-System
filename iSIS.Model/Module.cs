using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class Module : PersistentTemporalTitledEntity64
    {
        public virtual Module Parent { get; set; }

        private IList<Module> children;
        public virtual IList<Module> Children
        {
            get
            {
                if (null == this.children)
                    this.children = new List<Module>();
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
                foreach (Module child in this.Children)
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

        private void SaveChildren(SessionContext context, Module parent, IList<Module> children)
        {
            foreach (Module child in children)
            {
                child.Parent = parent;
                child.Persist(context);
                SaveChildren(context, child, child.Children);
            }
        }
    }
}
