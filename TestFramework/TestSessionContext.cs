using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using iSISModel;

namespace TestFramework
{
    [Serializable]
    public class TestSessionContext : SessionContext
    {
        public TestSessionContext()
        {
            if (null == Configuration.SessionFactory)
            {
                try
                {
                    NHibernate.Cfg.Configuration hibernateConfig = new NHibernate.Cfg.Configuration().Configure();
                    hibernateConfig.AddAssembly("iSISORM");
                    Configuration.SessionFactory = hibernateConfig.BuildSessionFactory();
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }

        //public TestSessionContext(iSystem system, System.Web.SessionState.HttpSessionState session)
        //    :base(system)
        //{
        //}

        //public override User User
        //{
        //    //get
        //    //{
        //    //    if (null == this.user)
        //    //        this.user = this.PersistenceSession.Get<User>(this.UserID);
        //    //    return this.user;
        //    //}
        //    set
        //    {
        //        if (null == value)
        //            throw new Exception("User is null");
        //        base.User = value;
        //        //this.UserSession = StartNewSession(value);
        //    }
        //}
    }
}
