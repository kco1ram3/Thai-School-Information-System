using System.ComponentModel.DataAnnotations;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class ClassLevel : PersistentTemporalTitledEntity64
    {
        #region persistent
        [UIHint("Int32Nullable")]
        public virtual int LevelNo { get; set; } //1=ป.1, ... 7=ม.1, ... 12=ม.6
        /// <summary>
        /// Primary school, Secondary school, All
        /// </summary>
        public virtual HierarchicalCategory Category { get; set; }

        #endregion

        public static IList<ClassLevel> ClassLevels { get; set; }
        public static void GetAll(ISession session)
        {
            ClassLevels = session.QueryOver<ClassLevel>()
                //.OrderBy(i => i.SeqNo).Asc
                                    .List();
        }

        public static bool operator <(ClassLevel left, ClassLevel right)
        {
            if (left == null || right == null)
                return false; //throw new Exception("One or both operands are null.");
            return left.LevelNo < right.LevelNo;
        }
        public static bool operator >(ClassLevel left, ClassLevel right)
        {
            if (left == null || right == null)
                return false; //throw new Exception("One or both operands are null.");
            return left.LevelNo > right.LevelNo;
        }
        /*
        public static bool operator ==(ClassLevel left, ClassLevel right)
        {
            if (left == null || right == null)
                return false; //throw new Exception("One or both operands are null.");
            return left.LevelNo == right.LevelNo;
        }
        */
        public static bool operator <=(ClassLevel left, ClassLevel right)
        {
            if (left == null || right == null)
                return false; //throw new Exception("One or both operands are null.");
            return left.LevelNo <= right.LevelNo;
        }
        public static bool operator >=(ClassLevel left, ClassLevel right)
        {
            if (left == null || right == null)
                return false; //throw new Exception("One or both operands are null.");
            return left.LevelNo >= right.LevelNo;
        }
        /*
        public static bool operator !=(ClassLevel left, ClassLevel right)
        {
            if (left == null || right == null)
                return false; //throw new Exception("One or both operands are null.");
            return left.LevelNo != right.LevelNo;
        }
        */
    }
}
