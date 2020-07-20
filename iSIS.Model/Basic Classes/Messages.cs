using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public static class Messages
    {
        public static class Error
        {
            public static string PersonNameEffectiveDateIsOutOfSequence = "1001-The effective date of the new PersonName instance is less than the current name's.";
        }
    }
}
