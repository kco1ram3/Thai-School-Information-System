using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSISModel
{
    public class UserSessionLog
    {
        public UserSessionLog(UserSession session, int pageID, string message)
        {
            this.Session = session;
            this.PageID = pageID;
            this.Message = message;
        }

        public virtual long ID { get; set; }
        public virtual UserSession Session { get; set; }
        public virtual int PageID { get; set; }
        public virtual string Message { get; set; }

    }
}
