using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iSISModel;
using iSISModel.Accounting;
using NHibernate;

namespace TestFramework
{
    /// <summary>
    /// Summary description for Test_Mappings
    /// </summary>
    [TestClass]
    public class Test_Mappings //: TestBase
    {
        public Test_Mappings()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private IList<T> GetAll<T>() where T : class
        {
            IList<T> list = null;
            try
            {
                list = Context.PersistenceSession.QueryOver<T>().List();
            }
            catch (Exception exc)
            {
                Exceptions.Add(exc);
            }
            return list;
        }

        private TestSessionContext Context
        {
            get { return TestBase.Context; }
        }
        private IList<Exception> exceptions;
        private IList<Exception> Exceptions
        {
            get
            {
                if (null == exceptions)
                    exceptions = new List<Exception>();
                return exceptions;
            }
        }

        [TestMethod]
        public void Test_Getting_CurriculumFrameworks()
        {
            IList<CurriculumFramework> cfs = CurriculumFramework.GetAll(TestBase.Context);
            foreach (CurriculumFramework cf in cfs)
            {
                foreach (DesiredOutcome oc in cf.DesiredOutcomes)
                {
                }
            }
        }

        [TestMethod]
        public void DeleteAll<T>() where T : class
        {
            IList<T> instances;
            instances = Context.PersistenceSession.QueryOver<T>().List<T>();
            //instances = Context.PersistenceSession.CreateCriteria<T>().List<T>();
            foreach (T i in instances)
            {
                Context.PersistenceSession.Delete(i);
            }
        }

        [TestMethod]
        public void Test_Create_And_Persist_A_School()
        {
            DeleteAll<SchoolAdministrator>();
            DeleteAll<School>();
            DeleteAll<Person>();

            DateTimeRange effectivePeriod = new DateTimeRange(new DateTime(2010, 01, 01));

            ReceivableItem riApplication = new ReceivableItem
            {
                Code = "",
                Title = new MultilingualString("th-TH", "ค่าเอกสารการสมัครเรียน", "en-US", ""),
            };
            ReceivableItem riRegistration = new ReceivableItem
            {
                Code = "",
                Title = new MultilingualString("th-TH", "ค่าขึ้นทะเบียน", "en-US", ""),
            };
            ReceivableItem riFee = new ReceivableItem
            {
                Code = "",
                Title = new MultilingualString("th-TH", "ค่าธรรมเนียมการศึกษา", "en-US", ""),
            };
            ReceivableItem riTuitionFee = new ReceivableItem
            {
                Code = "",
                Title = new MultilingualString("th-TH", "ค่ากิจกรรมนอกหลักสูตร", "en-US", ""),
            };
            ReceivableItem riLibraryFee = new ReceivableItem
            {
                Code = "",
                Title = new MultilingualString("th-TH", "ค่าบำรุงห้องสมุด", "en-US", ""),
            };


            School school = new School
            {
                MaxClassLevel = ClassLevel.ClassLevels[5], //ป. 6
                MinClassLevel = ClassLevel.ClassLevels[0], //ป. 1
                CurrentName = new OrgName
                {
                    EffectivePeriod = new DateTimeRange(new DateTime(1957, 01, 01)),
                    Title = new MultilingualString("th-TH", "โรงเรียนบ้านบางกะปิ", "en-US", "Banbangkapi School"),
                },
                EffectivePeriod = effectivePeriod,
                URL = "http://www.banbangkapi.ac.th",

                ReceivableItems = new List<ReceivableItem>
                {
                    riApplication,
                    riRegistration,
                    riFee,
                    riLibraryFee,
                    riTuitionFee,
                },

                ReceiptTemplates = new List<ReceiptTemplate>
                {
                    new ReceiptTemplate 
                    {
                        EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                        Title = new MultilingualString("th-TH", "ใบเสร็จรับเงินค่าสมัคร", "en-US", "Application Receipt"),
                        ReceiptTemplateItems = new List<ReceiptTemplateItem>
                        {
                            new ReceiptTemplateItem
                            {
                                DefaultAmount = 50,
                                ReceivableItem = riApplication,
                            },
                        },
                    },
                },
            };

            school.Persist(Context);

            HierarchicalCategory schoolPosition = Context.PersistenceSession.Get<HierarchicalCategory>(Context.CurrentConfiguration.SchoolPositionRootID);
            HierarchicalCategory directorPosition = schoolPosition.Children.First<HierarchicalCategory>(i => i.SeqNo == 1);
            HierarchicalCategory viceDirectorPosition = schoolPosition.Children.First<HierarchicalCategory>(i => i.SeqNo == 2);
            Person directorPerson = new Person
            {
                EffectivePeriod = new DateTimeRange(new DateTime(1960, 01, 01)),
                CurrentName = new PersonName
                {
                    EffectivePeriod = new DateTimeRange(new DateTime(1960, 01, 01)),
                    FirstName = new MultilingualString("th-TH", "พชรพงศ์", "en-US", "Pacharapong"),
                    LastName = new MultilingualString("th-TH", "ตรีเทพา", "en-US", "Trithepa"),
                }
            };
            directorPerson.Persist(Context);
            SchoolAdministrator director = new SchoolAdministrator(directorPerson, school, directorPosition, new DateTime(2011, 01, 01));
            director.Persist(Context);

            Person viceDirectorPerson = new Person
            {
                EffectivePeriod = new DateTimeRange(new DateTime(1960, 01, 01)),
                CurrentName = new PersonName
                {
                    FirstName = new MultilingualString("th-TH", "สุพจน์", "en-US", "Supoj"),
                    LastName = new MultilingualString("th-TH", "สุดสงวน", "en-US", "Sudsanguan"),
                    EffectivePeriod = new DateTimeRange(new DateTime(1960, 01, 01)),
                }
            };
            viceDirectorPerson.Persist(Context);
            SchoolAdministrator viceDirector = new SchoolAdministrator(viceDirectorPerson, school, viceDirectorPosition, new DateTime(2011, 01, 01));
            viceDirector.Persist(Context);

        }

        [TestMethod]
        public void Test_Creating_School_ChartOfAccounts()
        {
            IList<School> schools = Context.PersistenceSession.QueryOver<School>().List();
            if (schools.Count <= 0)
                return;
            School school = schools[0];
            AccountCategory chartOfAccount = new AccountCategory
            {
                EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                Organization = school,
                Accounts = new List<ChartOfAccount>
                {
                    new AccountCategory
                    {
                        Code = "1",
                        EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                        Title = new MultilingualString("th-TH", "สินทรัพย์", "en-US", "Asset"),
                        Accounts = new List<ChartOfAccount>
                        {
                            new AccountCategory 
                            { 
                                Code = "101", 
                                EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                                Title = new MultilingualString("th-TH", "เงินสด", "en-US", "Cash"), 
                                Accounts = new List<ChartOfAccount>
                                {
                                    new LedgerAccount 
                                    { 
                                        Code = "10101", 
                                        EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                                        IncreaseBalanceBy = iSISModel.Accounting.PostingRule.Debit,
                                        MonthsPerPeriod = 12,
                                        Title = new MultilingualString("th-TH", "เงินฝากกระแสรายวัน", "en-US", "Current Accounts"), 
                                    },
                                    new LedgerAccount 
                                    { 
                                        Code = "10102", 
                                        EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                                        IncreaseBalanceBy = iSISModel.Accounting.PostingRule.Debit,
                                        MonthsPerPeriod = 12,
                                        Title = new MultilingualString("th-TH", "เงินฝากออมทรัพย์", "en-US", "Saving Accounts"), 
                                    },
                                    new LedgerAccount 
                                    { 
                                        Code = "10103", 
                                        EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                                        IncreaseBalanceBy = iSISModel.Accounting.PostingRule.Debit,
                                        MonthsPerPeriod = 12,
                                        Title = new MultilingualString("th-TH", "เงินสดย่อย", "en-US", "Petty Cash"), 
                                    },
                                }
                            },
                            new LedgerAccount 
                            { 
                                Code = "102", 
                                EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                                IncreaseBalanceBy = iSISModel.Accounting.PostingRule.Debit,
                                MonthsPerPeriod = 12,
                                Title = new MultilingualString("th-TH", "บัญชีลูกหนี้", "en-US", "Account Receivable"), 
                            }
                        }
                    },
                    new AccountCategory
                    {
                        Code = "2",
                        EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                        Title = new MultilingualString("th-TH", "หนี้สิน", "en-US", "Liability"),
                        Accounts = new List<ChartOfAccount>
                        {
                            new LedgerAccount 
                            { 
                                Code = "201", 
                                EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                                IncreaseBalanceBy = iSISModel.Accounting.PostingRule.Credit,
                                MonthsPerPeriod = 12,
                                Title = new MultilingualString("th-TH", "บัญชีหนี้", "en-US", "Account Payable"), 
                            },
                            new LedgerAccount 
                            { 
                                Code = "202", 
                                EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                                IncreaseBalanceBy = iSISModel.Accounting.PostingRule.Credit,
                                MonthsPerPeriod = 12,
                                Title = new MultilingualString("th-TH", "เงินกู้ธนาคาร", "en-US", "Bank Loans"), 
                            },
                            new AccountCategory
                            {
                                Code = "203",
                                EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                                Title = new MultilingualString("th-TH", "ส่วนของผู้ถือหุ้น", "en-US", "Liability"),
                                Accounts = new List<ChartOfAccount>
                                {
                                    new LedgerAccount 
                                    { 
                                        Code = "20301", 
                                        EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                                        IncreaseBalanceBy = iSISModel.Accounting.PostingRule.Credit,
                                        MonthsPerPeriod = 12,
                                        Title = new MultilingualString("th-TH", "นาย เอ", "en-US", "Mr. A"), 
                                    },
                                    new LedgerAccount 
                                    { 
                                        Code = "20302", 
                                        EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                                        IncreaseBalanceBy = iSISModel.Accounting.PostingRule.Credit,
                                        MonthsPerPeriod = 12,
                                        Title = new MultilingualString("th-TH", "นาง บี", "en-US", "Ms. B"), 
                                    },
                                }
                            },
                        }
                    },
                    new AccountCategory
                    {
                        Code = "3",
                        EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                        Title = new MultilingualString("th-TH", "รายได้", "en-US", "Revenue"),
                        Accounts = new List<ChartOfAccount>
                        {
                            new LedgerAccount 
                            { 
                                Code = "301", 
                                EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                                IncreaseBalanceBy = iSISModel.Accounting.PostingRule.Credit,
                                MonthsPerPeriod = 12,
                                Title = new MultilingualString("th-TH", "บัญชีลูกหนี้", "en-US", "Account Receivable"), 
                            }
                        }
                    },
                    new AccountCategory
                    {
                        Code = "5",
                        EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                        Title = new MultilingualString("th-TH", "ค่าใช้จ่าย", "en-US", "Expenses"),
                        Accounts = new List<ChartOfAccount>
                        {
                            new LedgerAccount 
                            { 
                                Code = "501", 
                                EffectivePeriod = new DateTimeRange(new DateTime(2013, 01, 01)),
                                IncreaseBalanceBy = iSISModel.Accounting.PostingRule.Debit,
                                MonthsPerPeriod = 12,
                                Title = new MultilingualString("th-TH", "", "en-US", "Account Payable"), 
                            }
                        }
                    },
                },
            };
            using (Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    chartOfAccount.Persist(Context);
                    //school.FiscalYearEndDate = new DateTime(2013, 12, 31);
                    //school.ChartOfAccount = chartOfAccount;
                    //Context.PersistenceSession.Update(school);
                    Context.PersistenceSession.Transaction.Commit();
                }
                catch (Exception exc)
                {
                    Context.PersistenceSession.Transaction.Rollback();
                    throw exc;
                }
            }
        }

        [TestMethod]
        public void Test_Getting_All()
        {
            Exceptions.Clear();
            GetAll<iSISModel.Accounting.AccountCategory>();
            GetAll<iSISModel.Accounting.AccountingPeriod>();
            GetAll<iSISModel.Accounting.AccountingTransaction>();
            GetAll<iSISModel.Accounting.CreditEntry>();
            GetAll<iSISModel.Accounting.DebitEntry>();
            GetAll<iSISModel.Accounting.Ledger>();
            GetAll<iSISModel.Accounting.LedgerAccount>();

            IList<Absence> l = GetAll<iSISModel.Absence>();
            GetAll<iSISModel.AcademicAchievement>();
            GetAll<iSISModel.AcademicEventParticipation>();
            GetAll<iSISModel.Admission>();
            GetAll<iSISModel.AdmissionTest>();
            GetAll<iSISModel.AdmitCurriculum>();
            GetAll<iSISModel.AdmissionTestRoom>();

            GetAll<iSISModel.AlternateSchool>();
            GetAll<iSISModel.Application>();
            GetAll<iSISModel.ClassLevel>();
            GetAll<iSISModel.ClassLevelOutcome>();
            GetAll<iSISModel.ClassLevelSection>();
            //GetAll<iSISModel.ClassMember>();
            GetAll<iSISModel.Classroom>();
            GetAll<iSISModel.ClassroomStudent>();
            GetAll<iSISModel.ClassroomTeacher>();

            GetAll<iSISModel.CourseSection>();
            GetAll<iSISModel.CourseSectionAppraisal>();
            GetAll<iSISModel.CourseSectionPerformance>();
            GetAll<iSISModel.CourseSectionStudent>();
            GetAll<iSISModel.CourseSectionTeacher>();

            GetAll<iSISModel.Configuration>();
            GetAll<iSISModel.ContinuousGradingSystem>();
            GetAll<iSISModel.Country>();
            GetAll<iSISModel.Course>();
            GetAll<iSISModel.CurriculumFramework>();
            GetAll<iSISModel.DesiredOutcome>();
            GetAll<iSISModel.DiscreteGrade>();
            GetAll<iSISModel.DiscreteGradingSystem>();
            GetAll<iSISModel.Education>();
            GetAll<iSISModel.Experience>();
            GetAll<iSISModel.GeographicAddress>();
            GetAll<iSISModel.GeographicRegion>();

            GetAll<iSISModel.HierarchicalCategory>();
            GetAll<Language>();
            GetAll<iSISModel.Organization>();
            GetAll<iSISModel.OrgName>();
            GetAll<iSISModel.OutcomeCategory>();

            GetAll<PartyAddress>();
            GetAll<PartyIdentity>();
            GetAll<iSISModel.Password>();
            GetAll<iSISModel.PerformanceIndicator>();
            GetAll<iSISModel.PerformanceMeasurement>();
            GetAll<iSISModel.Person>();
            GetAll<iSISModel.PersonName>();
            GetAll<iSISModel.Photo>();
            GetAll<iSISModel.PhysicalRoom>();
            GetAll<iSISModel.Punishment>();
            GetAll<iSISModel.Reward>();
            GetAll<iSISModel.Role>();
            GetAll<iSISModel.RoyalDecoration>();

            GetAll<iSISModel.Receipt>();
            GetAll<iSISModel.ReceiptItem>();
            GetAll<iSISModel.ReceiptTemplate>();
            GetAll<iSISModel.ReceiptTemplateItem>();
            GetAll<iSISModel.ReceivableItem>();

            GetAll<iSISModel.School>();
            GetAll<iSISModel.SchoolOutcomeCategoryGrading>();
            GetAll<iSISModel.Semester>();
            GetAll<iSISModel.Student>();
            GetAll<iSISModel.StudentAcademicYear>();
            GetAll<iSISModel.StudentApplication>();
            GetAll<iSISModel.StudentSemester>();
            GetAll<iSISModel.Teacher>();
            GetAll<iSISModel.TestScore>();
            GetAll<iSISModel.User>();
            GetAll<iSISModel.UserRole>();

            if (Exceptions.Count > 0)
            {
                Assert.Fail(String.Format("There are {0} exceptions in this.exceptions.", Exceptions.Count));
            }
        }
    }
}
