using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class UserSession 
    {
        public virtual int ID { get; set; }
        public virtual DateTimeRange LoginPeriod { get; set; }
        public virtual User User { get; set; }

        public virtual void Log(SessionContext context, int pageID, string message)
        {
            context.Persist(new UserSessionLog(this, pageID, message));
        }
    }
}
