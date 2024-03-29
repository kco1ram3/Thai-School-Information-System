﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public abstract class PersistentEntity32
    {
        #region persistent
        
        /// <summary>
        /// Unique object ID generated by persistent store manager (DB Server).
        /// </summary>
        public virtual int ID { get; set; }
        public virtual string Code { get; set; }
        public virtual UserAction CreateAction { get; set; }
        public virtual UserAction TerminateAction { get; set; }
        public virtual string Reference { get; set; }
        public virtual string Remark { get; set; } 

        #endregion

        public virtual Object Tag { get; set; } 

        public virtual void Persist(SessionContext context)
        {
            context.Persist(this);
        }
    }
}
