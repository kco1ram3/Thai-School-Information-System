using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSIS.Controllers;
using NHibernate;
using TSIS.Models;
using TSIS.Filters;
using TSIS.Classes;

namespace TSIS.Areas.Student.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class TimeAttendanceStudentController : BaseController
    {
        // GET: Student/TimeAttendanceStudent
        public ActionResult Index()
        {
            IList<iSISModel.StudentTimeAttendance> data = getTimeAttendanceStudent();
            return View(data);
        }

        public ActionResult GridViewTimeAttendanceStudent()
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.Student> student = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.Student>()
                                           .Where(x => x.School.ID == school.ID)
                                           .And(x => x.EffectivePeriod.To > DateTime.Today)
                                           .OrderBy(x => x.IDNo).Asc
                                           .List();
            ViewData["ComboBoxItemsStudnet"] = ModelsRepository.GetComboBoxItems(student);

            IList<iSISModel.StudentTimeAttendance> data = getTimeAttendanceStudent();
            return PartialView("_GridViewTimeAttendanceStudent", data);
        }

        [HttpPost]
        public ActionResult GridViewTimeAttendanceStudentAddNewOrUpdate(iSISModel.StudentTimeAttendance studentTimeAttendance)
        {
            iSISModel.StudentTimeAttendance update = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.StudentTimeAttendance>()
                                           .Where(x => x.ID == studentTimeAttendance.ID)
                                           .SingleOrDefault();

            string fingerScannerID = DevExpress.Web.Mvc.EditorExtension.GetValue<string>("FingerScannerID");
            DateTime? timeAttendanceDate = DevExpress.Web.Mvc.EditorExtension.GetValue<DateTime?>("TimeAttendanceDate");
            DateTime? timeFrom = DevExpress.Web.Mvc.EditorExtension.GetValue<DateTime?>("TimeFrom");
            DateTime? timeTo = DevExpress.Web.Mvc.EditorExtension.GetValue<DateTime?>("TimeTo");
            string comboBoxStudent = DevExpress.Web.Mvc.EditorExtension.GetValue<string>("ComboBoxStudent");

            if (timeAttendanceDate != null && timeFrom != null & timeTo != null)
            {
                DateTime date = (DateTime)timeAttendanceDate;
                DateTime from = (DateTime)timeFrom;
                DateTime to = (DateTime)timeTo;
                DateTime f = new DateTime(date.Year, date.Month, date.Day, from.Hour, from.Minute, from.Second);
                DateTime t = new DateTime(date.Year, date.Month, date.Day, to.Hour, to.Minute, to.Second);

                if (update == null)
                {
                    update = new iSISModel.StudentTimeAttendance();
                    update.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
                }

                update.Student = ModelsRepository.GetStudentByID(!string.IsNullOrEmpty(comboBoxStudent) ? long.Parse(comboBoxStudent) : 0);
                update.FingerScannerID = fingerScannerID;
                update.TimeAttendanceDate = date;
                update.TimeAttendancePeriod = new iSISModel.DateTimeRange(f, t);
                using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
                {
                    try
                    {
                        update.Persist(base.Context);

                        tran.Commit();
                    }
                    catch (Exception exc)
                    {
                        tran.Rollback();
                        throw exc;
                    }
                }
            }

            IList<iSISModel.StudentTimeAttendance> data = getTimeAttendanceStudent();
            return PartialView("_GridViewTimeAttendanceStudent", data);
        }

        [HttpPost]
        public ActionResult GridViewTimeAttendanceStudentDelete(int ID)
        {
            iSISModel.StudentTimeAttendance delete = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.StudentTimeAttendance>()
                                           .Where(x => x.ID == ID)
                                           .SingleOrDefault();
            delete.EffectivePeriod.To = DateTime.Today;
            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    delete.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }

            IList<iSISModel.StudentTimeAttendance> data = getTimeAttendanceStudent();
            return PartialView("_GridViewTimeAttendanceStudent", data);
        }

        private IList<iSISModel.StudentTimeAttendance> getTimeAttendanceStudent()
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.StudentTimeAttendance> studentTimeAttendance = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.StudentTimeAttendance>()
                                               .And(x => x.EffectivePeriod.To > DateTime.Today)
                                               .List();
            return studentTimeAttendance.Where(x => x.Student.School.ID == school.ID).ToList();
        }
    }
}