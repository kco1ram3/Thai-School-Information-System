using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using NHibernate;
using NHibernate.Criterion;
using iSISModel;
//using iSISModel.Log;
using iSISModel.Personalization;

namespace TestFramework
{
    [Serializable]
    public class WebSessionContext : SessionContext
    {
        static WebSessionContext()
        {
            if (null == Configuration.SessionFactory)
            {
                NHibernate.Cfg.Configuration hibernateConfig = new NHibernate.Cfg.Configuration().Configure();
                hibernateConfig.AddAssembly("iSISORM");
                Configuration.SessionFactory = hibernateConfig.BuildSessionFactory();
            }
        }


        private System.Web.SessionState.HttpSessionState sessionState;


        public WebSessionContext(System.Web.SessionState.HttpSessionState session)
        {
            this.sessionState = session;
        }

        public override User User
        {
            get
            {
                if (null == base.User)
                    //Get user from database using NHibernate session and UserID
                    base.User = base.PersistenceSession.Get<User>(this.UserID);
                return base.User;
            }
            set
            {
                if (null == value)
                    throw new Exception("User is null");
                base.User = value;
                this.UserID = value.ID;
            }
        }

        private UserPersonalization personalization;
        public virtual UserPersonalization Personalization
        {
            get
            {
                if (this.sessionState["UserPersID"] == null)
                {
                    personalization = this.PersistenceSession
                                            .CreateCriteria<UserPersonalization>()
                                            .Add(Expression.Eq("User", this.User))
                                            .UniqueResult<UserPersonalization>();
                    this.sessionState["UserPersID"] = personalization.ID;
                }
                else if (this.personalization == null)
                {
                    personalization = this.PersistenceSession.Get<UserPersonalization>((int)this.sessionState["UserPersID"]);
                }
                return personalization;
            }
            set
            {
                this.personalization = value;
                this.sessionState["UserID"] = value.ID;
            }
        }

        private long userID;
        public virtual long UserID
        {
            get
            {
                if (this.userID == 0 && this.sessionState["UserID"] != null)
                    this.userID = (int)this.sessionState["UserID"];
                return userID;
            }
            set
            {
                this.sessionState["UserID"] = this.userID = value;
            }
        }

        public override UserSession UserSession
        {
            get
            {
                if (null == base.UserSession)
                    base.UserSession = this.PersistenceSession.Get<UserSession>(this.UserSessionID);
                return base.UserSession;
            }
            set
            {
                if (null == value) return;
                base.UserSession = value;
                this.UserSessionID = value.ID;
            }
        }

        private int userSessionID;
        public virtual int UserSessionID
        {
            get
            {
                if (this.userSessionID == 0 && this.sessionState["UserSessionID"] != null)
                    this.userSessionID = (int)this.sessionState["UserSessionID"];
                return userSessionID;
            }
            set
            {
                this.sessionState["UserSessionID"] = this.userID = value;
            }
        }

    }
}
