using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using iSISDemo.Models;
using iSISDemo.Filters;
using iSISDemo.Classes;

namespace iSISDemo.Controllers.Setup
{
    [UserFilterAuthorizeAttribute]
    public class AutomaticGradingController : BaseController
    {
        // GET: AutomaticGrading
        public ActionResult Index()
        {
            return View(DiscreteGradeData());
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);

            IList<iSISModel.DiscreteGrade> discreteGrade = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.DiscreteGrade>()
                                                .List();

            discreteGrade =  discreteGrade.Where(x => x.GradingSystem.EffectivePeriod.To > DateTime.Today).ToList();

            foreach (iSISModel.DiscreteGrade item in discreteGrade)
            {
                long automaticGradingID = (!string.IsNullOrEmpty(collection["id_" + item.ID])) ? long.Parse(collection["id_" + item.ID]) : 0;
                int percentage = (!string.IsNullOrEmpty(collection["percentage_" + item.ID])) ? int.Parse(collection["percentage_" + item.ID]) : 0;

                iSISModel.AutomaticGrading automaticGrading = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.AutomaticGrading>()
                                          .Where(x => x.ID == automaticGradingID)
                                          .SingleOrDefault();

                using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
                {
                    try
                    {
                        if (automaticGrading == null)
                        {
                            automaticGrading = new iSISModel.AutomaticGrading();
                            automaticGrading.School = school;
                            automaticGrading.DiscreteGrade = item;
                            automaticGrading.Percentage = percentage;
                            automaticGrading.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
                        }
                        else
                        {
                            if (percentage != automaticGrading.Percentage)
                            {
                                automaticGrading.EffectivePeriod.To = DateTime.Today;
                                automaticGrading.Persist(base.Context);

                                automaticGrading = new iSISModel.AutomaticGrading();
                                automaticGrading.School = school;
                                automaticGrading.DiscreteGrade = item;
                                automaticGrading.Percentage = percentage;
                                automaticGrading.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
                            }
                        }

                        automaticGrading.Persist(base.Context);

                        tran.Commit();
                    }
                    catch (Exception exc)
                    {
                        tran.Rollback();
                        throw exc;
                    }
                }
            }
            return View(DiscreteGradeData());
        }

        private IList<iSISModel.DiscreteGrade> DiscreteGradeData()
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);

            IList<iSISModel.AutomaticGrading> automaticGrading = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.AutomaticGrading>()
                                          .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                          .And(x => x.School == school)
                                          .List();

            ViewData["AutomaticGrading"] = automaticGrading;

            IList<iSISModel.DiscreteGrade> discreteGrade = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.DiscreteGrade>()
                                                .List();

            return discreteGrade.Where(x => x.GradingSystem.EffectivePeriod.To > DateTime.Today).ToList();
        }
    }
}