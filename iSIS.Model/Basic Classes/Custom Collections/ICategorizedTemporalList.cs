using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public interface ICategorizedTemporal : ITemporal
    {
        HierarchicalCategory Category { get; }
    }

    public interface ICategorizedTemporalList<T> : IList<T> where T : ICategorizedTemporal
    {
        //void Add(T newInstance);
        //void Remove(T existingInstance);
        T GetInstance(DateTime when, String categoryCode);
        T GetInstance(DateTime when, HierarchicalCategory category);
        IList<T> GetInstances(HierarchicalCategory category);
        IList<T> GetInstances(DateTime when);
        bool ContainsCategory(DateTime when, HierarchicalCategory category);
        bool ContainsCategoryParent(DateTime when, HierarchicalCategory parentCategory);
    }
}
