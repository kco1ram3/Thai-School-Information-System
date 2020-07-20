using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.UserTypes;
using NHibernate.Engine;
//using NHibernate.Collection.Generic;

namespace iSISModel
{
    public interface ITemporalList<T> : IList<T> where T : ITemporal
    {
        T Current { get; set; }
        //void Add(T newInstance);
        //void Remove(T existingInstance);
        T GetInstance(DateTime when);
    }
}