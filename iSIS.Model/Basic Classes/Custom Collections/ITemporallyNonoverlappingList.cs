using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel.Basic_Classes
{
    public interface ITemporallyNonoverlappingList<T> : ITemporalList<T> where T : ITemporal
    {
        //T Current { get; set; }
        //void Add(T newInstance);
        //void Remove(T existingInstance);
        //T GetInstance(DateTime when);
    }
}
