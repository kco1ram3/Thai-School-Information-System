using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using NHibernate;

namespace iSISModel
{
    public class Configuration
    {
        private static ISessionFactory sessionFactory;
        public static ISessionFactory SessionFactory
        {
            get { return sessionFactory; }
            set
            {
                sessionFactory = value;
                try
                {
                    //Initialize Langauges and Configuration
                    ISession session = sessionFactory.OpenSession();
                    Language.GetAll(session);
                    ClassLevel.GetAll(session);
                    Configuration.GetConfiguration(session);
                    session.Close();
                }
                catch (Exception exc)
                {
                    throw new Exception("Cannot get configuration", exc);
                }
            }
        }

        public static Configuration CurrentConfiguration { get; set; }
        public static void GetConfiguration(ISession session)
        {
            CurrentConfiguration = session.QueryOver<Configuration>().SingleOrDefault();
        }

        public virtual Language CurrentLanguage { get; set; }

        public virtual ISession Session { get; set; }

        private CultureInfo defaultDateCulture;
        public virtual CultureInfo DefaultDateCulture
        {
            get
            {
                if (null == this.defaultDateCulture && !string.IsNullOrEmpty(this.DefaultDateCultureName))
                {
                    this.defaultDateCulture = CultureInfo.GetCultureInfo(this.DefaultDateCultureName);
                }
                return this.defaultDateCulture;
            }
            set
            {
                this.defaultDateCulture = value;
                if (null == value)
                    this.DefaultDateCultureName = null;
                else
                    this.DefaultDateCultureName = value.Name;
            }
        }

        private Country defaultCountry;
        public virtual Country DefaultCountry
        {
            get
            {
                if (null == this.defaultCountry && !string.IsNullOrEmpty(this.DefaultCountryCode))
                {
                    //this.defaultCountry = Country.Countrys[this.DefaultCountryCode];
                }
                return this.defaultCountry;
            }
            set
            {
                this.defaultCountry = value;
                if (null == value)
                    this.DefaultCountryCode = null;
                else
                    this.DefaultCountryCode = value.Code;
            }
        }

        private Language defaultLanguage;
        public virtual Language DefaultLanguage
        {
            get
            {
                if (null == this.defaultLanguage && !string.IsNullOrEmpty(this.DefaultLanguageCode))
                {
                    //this.defaultLanguage = Language.Languages[this.DefaultLanguageCode];
                }
                return this.defaultLanguage;
            }
            set
            {
                this.defaultLanguage = value;
                if (null == value)
                    this.DefaultLanguageCode = null;
                else
                    this.DefaultLanguageCode = value.Code;
            }
        }

        #region persistent

        public virtual int ID { get; set; }
        public virtual int SystemID { get; set; }
        public virtual DateTimeRange EffectivePeriod { get; set; }

        public virtual int AcademicLevelRootID { get; set; }
        public virtual int BloodGroupRootID { get; set; }
        public virtual int CourseCategoryRootID { get; set; }
        public virtual int GenderRootID { get; set; }
        public virtual int MajorRootID { get; set; }
        public virtual int OccupationRootID { get; set; }
        public virtual int RaceRootID { get; set; }
        public virtual int ReligionRootID { get; set; }
        public virtual int StudentStatusRootID { get; set; }

        public virtual int CurriculumCourseCategoryRootID { get; set; }
        public virtual int EducationLevelRootID { get; set; }
        public virtual int RoyalDecorationRootID { get; set; }

        public virtual int PersonPersonRelationshipCategoryRootID { get; set; }
		public virtual int InterPersonRelationshipCategoryRootID { get; set; }
        public virtual int FatherCategoryID { get; set; }
        public virtual int MotherCategoryID { get; set; }
        public virtual int GuardianCategoryID { get; set; }
        public virtual int RelativeCategoryID { get; set; }
        public virtual int SchoolPositionRootID { get; set; }
        public virtual int SchoolSupervisorCategoryRootID { get; set; }

        public virtual string DefaultCountryCode { get; set; }
        public virtual string DefaultDateCultureName { get; set; }
        public virtual string DefaultDateFormat { get; set; }
        public virtual string DefaultLanguageCode { get; set; }

        #endregion persistent

        public static HierarchicalCategory GetHierarchicalCategoryRoot(SessionContext context, int rootID)
        {
            return HierarchicalCategory.GetInstance(context, rootID);
        }

        public virtual HierarchicalCategory GetAcademicLevelRoot(SessionContext context)
        {
            return HierarchicalCategory.GetInstance(context, this.AcademicLevelRootID);
        }

        public virtual void Persist(SessionContext context)
        {
            context.Persist(this);
        }

        public static IList<HierarchicalCategory> GetChildrenOfHierarchicalCategory(SessionContext context, int rootID)
        {
            HierarchicalCategory cat = GetHierarchicalCategory(context, rootID);
            if (null == cat)
                throw new Exception("Could not find category of ID " + rootID.ToString());

            return cat.Children;
        }

        public static HierarchicalCategory GetHierarchicalCategory(SessionContext context, int rootID)
        {
            return context.PersistenceSession
                                 .QueryOver<HierarchicalCategory>()
                                 .Where(c => c.ID == rootID)
                                 .SingleOrDefault()
                                 ;
        }
    }
}
