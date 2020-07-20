using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Globalization;

namespace iSISModel
{
    public class SessionContext
    {
        public virtual User User { get; set; }
        public virtual UserSession UserSession { get; set; }

        private ISession persistenceSession;
        public virtual ISession PersistenceSession
        {
            get
            {
                if (null == this.persistenceSession)
                {
                    if (null == Configuration.SessionFactory)
                    {
                        throw new Exception("Session fatory is null.");
                        //try
                        //{
                        //    NHibernate.Cfg.Configuration hibernateConfig = new NHibernate.Cfg.Configuration().Configure();
                        //    hibernateConfig.AddAssembly("iSISORM");
                        //    Configuration.SessionFactory = hibernateConfig.BuildSessionFactory();
                        //}
                        //catch (Exception exc)
                        //{
                        //    throw exc;
                        //}
                    }
                    this.persistenceSession = Configuration.SessionFactory.OpenSession();
                }
                return this.persistenceSession;
            }

            set
            {
                this.persistenceSession = value;
            }
        }

        internal void Persist(object persistentEntity)
        {
            this.PersistenceSession.SaveOrUpdate(persistentEntity);
        }

        public Configuration CurrentConfiguration
        {
            get { return Configuration.CurrentConfiguration; }
        }
        
        public string CurrentLanguageCode { get; set; }
        public string CurrentDateCultureName { get; set; }
        public string CurrentDateFormat { get; set; }

        private CultureInfo currentDateCulture;
        public CultureInfo CurrentDateCulture
        {
            get
            {
                if (null == this.currentDateCulture && !string.IsNullOrEmpty(this.CurrentDateCultureName))
                    this.currentDateCulture = CultureInfo.GetCultureInfo(this.CurrentDateCultureName);
                return this.currentDateCulture;
            }
            set
            {
                if (null == value)
                    this.CurrentDateCultureName = null;
                else
                    this.CurrentDateCultureName = value.Name;
                this.currentDateCulture = value;
            }
        }

        private Language currentLanguage;
        public Language CurrentLanguage
        {
            get
            {
                if (null == this.currentLanguage && !string.IsNullOrEmpty(this.CurrentLanguageCode))
                    this.currentLanguage = new Language(this.CurrentLanguageCode);
                return this.currentLanguage;
            }
            set
            {
                if (null == value)
                    this.CurrentLanguageCode = null;
                else
                {
                    this.CurrentLanguageCode = value.Code;
                    System.Web.HttpContext.Current.Session["languageCode"] = value.Code;
                }
                this.currentLanguage = value;
            }
        }
    }
}
