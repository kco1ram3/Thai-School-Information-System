using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;
using iSISModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Criterion;

namespace TestFramework
{
    public abstract class TestBase
    {
        //public static readonly iSystem MySystem = new iSystem { SystemID = 0 };
        public static readonly TestSessionContext Context;
        //public static Language th;//TH
        //public static Language en;//EN
        public static readonly int BizPortalAdminSystemID = 41;
        public static readonly int BizPortalClientSystemID = 42;

        static TestBase()
        {
            //if (null == BizPortalConfiguration.SessionFactory)
            //    try
            //    {
            //        NHibernate.Cfg.Configuration hibernateConfig = new NHibernate.Cfg.Configuration().Configure();
            //        hibernateConfig.AddAssembly("iSabayaORM");
            //        hibernateConfig.AddAssembly("iSabaya.ExtensibleORM");
            //        hibernateConfig.AddAssembly("BizPortalORM");
            //        BizPortalConfiguration.SessionFactory = hibernateConfig.BuildSessionFactory();
            //    }
            //    catch (Exception exc)
            //    {
            //        throw new Exception("Can't create persistence session!", exc);
            //    }
            ////Context = new BizPortalSessionContext(hibernateConfig.BuildSessionFactory());
            //Context = new BizPortalSessionContext();
            //BizPortal.Functions.Main.Initialize();
            try
            {
                //System.Web.SessionState.HttpSessionState session = null;
                Context = new TestSessionContext();
            }
            catch (Exception exc)
            {
                throw new Exception("Can't create persistence session!", exc);
            }
            //th = Context.Languages[0];//TH
            //en = Context.Languages[1];//EN
        }

        public static void TruncateTable(params string[] tableNames)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string tn in tableNames)
            {
                sb.Append("truncate table ");
                sb.Append(tn);
                sb.Append(";");
            }
            Context.PersistenceSession.CreateSQLQuery(sb.ToString()).ExecuteUpdate();
        }

        public static void RunSQLCommand(string commandString)
        {
            Context.PersistenceSession.CreateSQLQuery(commandString).ExecuteUpdate();
        }

        public static IList<T> GetAll<T>() where T : class
        {
            IList<T> list = null;
            ICriteria crit = Context.PersistenceSession.CreateCriteria<T>();
            list = crit.List<T>();
            //try
            //{
            //    list = crit.List<T>();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    throw e;
            //}
            return list;
        }
    }
}