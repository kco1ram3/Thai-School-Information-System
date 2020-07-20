using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public static class ClassExtensions
    {
        public static bool IsNullOrEmpty(this DateTimeRange ti)
        {
            return null == ti || ti.IsEmpty;
        }

        public static MultilingualString Clone(this MultilingualString original)
        {
            if (MultilingualString.IsNullOrEmpty(original))
                return null;
            else
                return new MultilingualString(original);
        }

        /// <summary>
        /// Expire the current one, if any, before adding the new member
        /// </summary>
        /// <param name="list"></param>
        /// <param name="newMember"></param>
        public static void AddNewCategorizedMemberAfterExpireCurrent<T>(this IList<T> list, T newMember) where T : ICategorizedTemporal
        {
            if (null == list) return;
            if (newMember.EffectivePeriod.IsNullOrEmpty())
                throw new Exception("The effective period of the new party address is empty.");

            //Expire the current if any
            foreach (T pa in list)
            {
                //Find current member of the same category
                if (pa.Category == newMember.Category && pa.EffectivePeriod.IsEffectiveNow())
                {
                    if (pa.EffectivePeriod.From >= newMember.EffectivePeriod.From)
                        throw new Exception("The effective period of the new party address is empty.");
                    pa.EffectivePeriod.Expire(newMember.EffectivePeriod.From);
                    break;
                }
            }

            list.Add(newMember);
        }

        public static T GetCurrentMemberOfCategory<T>(this IList<T> list, HierarchicalCategory category) where T : class, ICategorizedTemporal
        {
            foreach (T pa in list)
            {
                if (pa.Category == category && pa.EffectivePeriod.IsEffectiveNow())
                    return pa;
            }
            return null;
        }


    }
}
