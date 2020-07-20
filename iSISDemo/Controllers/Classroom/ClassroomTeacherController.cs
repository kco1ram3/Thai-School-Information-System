using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using iSISDemo.Models;
using iSISDemo.Filters;
using iSISDemo.Classes;

namespace iSISDemo.Controllers.Classroom
{
    [UserFilterAuthorizeAttribute]
    public class ClassroomTeacherController : BaseController
    {
        // GET: ClassroomTeacher
        public ActionResult Index()
        {
            return View(ClassroomTeacherData());
        }

        public ActionResult GridViewClassroomTeacherData()
        {
            return PartialView("_GridViewClassroomTeacherData", ClassroomTeacherData());
        }

        [HttpPost]
        public ActionResult GridViewClassroomTeacherDataAddNewOrUpdate(iSISModel.ClassroomTeacher classroomTeacher, FormCollection collection)
        {
            CreateOrUpdate(classroomTeacher, collection);
            return PartialView("_GridViewClassroomTeacherData", ClassroomTeacherData());
        }

        [HttpPost]
        public ActionResult GridViewClassroomTeacherDataDelete(long ID)
        {
            iSISModel.ClassroomTeacher classroomTeacher = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.ClassroomTeacher>()
                                          .Where(x => x.ID == ID)
                                          .SingleOrDefault();

            classroomTeacher.EffectivePeriod.To = DateTime.Today;

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    classroomTeacher.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewClassroomTeacherData", ClassroomTeacherData());
        }

        private void CreateOrUpdate(iSISModel.ClassroomTeacher classroomTeacher, FormCollection collection)
        {
            iSISModel.ClassroomTeacher update = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.ClassroomTeacher>()
                                          .Where(x => x.ID == classroomTeacher.ID)
                                          .SingleOrDefault();

            int academicYear = (!string.IsNullOrEmpty(collection["ComboBoxAcademicYear_VI"])) ? int.Parse(collection["ComboBoxAcademicYear_VI"]) : 0;
            int semesterNo = (!string.IsNullOrEmpty(collection["ComboBoxSemester_VI"])) ? int.Parse(collection["ComboBoxSemester_VI"]) : 0;
            Int64 classLevelID = (!string.IsNullOrEmpty(collection["ComboBoxClassLevel_VI"])) ? Int64.Parse(collection["ComboBoxClassLevel_VI"]) : 0;
            Int64 roomID = (!string.IsNullOrEmpty(collection["ComboBoxRoom_VI"])) ? Int64.Parse(collection["ComboBoxRoom_VI"]) : 0;
            Int64 teacherID = (!string.IsNullOrEmpty(collection["ComboBoxTeacher_VI"])) ? Int64.Parse(collection["ComboBoxTeacher_VI"]) : 0;

            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);

            iSISModel.Semester semester = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Semester>()
                                          .Where(x => x.AcademicYear == academicYear)
                                          .And(x => x.SemesterNo == semesterNo)
                                          .And(x => x.School.ID == school.ID)
                                          .And(x => x.EffectivePeriod.To > DateTime.Today)
                                          .SingleOrDefault();

            iSISModel.ClassLevelSection classLevelSection = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.ClassLevelSection>()
                                          .Where(x => x.ClassLevel.ID == classLevelID)
                                          .And(x => x.School.ID == school.ID)
                                          .And(x => x.Semester.ID == semester.ID)
                                          .And(x => x.EffectivePeriod.To > DateTime.Today)
                                          .SingleOrDefault();

            iSISModel.Classroom classroom = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Classroom>()
                                          .Where(x => x.Semester.ID == semester.ID)
                                          .And(x => x.ClassLevelSection.ID == classLevelSection.ID)
                                          .And(x => x.Room.ID == roomID)
                                          .And(x => x.School.ID == school.ID)
                                          .SingleOrDefault();

            if (classroom == null)
            {
                classroom = new iSISModel.Classroom();
                classroom.Semester = semester;
                classroom.ClassLevelSection = classLevelSection;
                classroom.Room = ModelsRepository.GetRoomByID(roomID);
                classroom.School = school;
            }

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    if (classroom.ID == 0)
                    {
                        classroom.Persist(base.Context);
                    }

                    iSISModel.ClassroomTeacher duplicate = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.ClassroomTeacher>()
                                          .Where(x => x.Classroom.ID == classroom.ID)
                                          .And(x => x.Teacher.ID == teacherID)
                                          .And(x => x.EffectivePeriod.To > DateTime.Today)
                                          .And(x => x.ID != classroomTeacher.ID)
                                          .SingleOrDefault();

                    if (duplicate == null)
                    {
                        if (update == null)
                        {
                            update = new iSISModel.ClassroomTeacher();
                            update.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
                        }
                        update.Classroom = classroom;
                        update.Teacher = ModelsRepository.GetTeacherByID(teacherID);
                        update.Persist(base.Context);
                    }

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
        }

        private IList<iSISModel.ClassroomTeacher> ClassroomTeacherData()
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);

            IList<iSISModel.Semester> semester = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.Semester>()
                                          .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                          .List();

            List<int> academicYear = semester.GroupBy(x => x.AcademicYear).Select(x => x.Key).ToList();
            academicYear.Sort();
            ViewData["AcademicYear"] = academicYear;

            IList<iSISModel.Teacher> teacher = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.Teacher>()
                                               .Where(t => t.EffectivePeriod.To > DateTime.Today)
                                               .And(t => t.School == school)
                                               .List();
            ViewData["Teacher"] = teacher;

            IList<iSISModel.ClassroomTeacher> courseSectionTeacher = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.ClassroomTeacher>()
                                                .Where(x => x.EffectivePeriod.To > DateTime.Today)
                //.And(x => x.CourseSection.School.ID == school.ID)
                //.OrderBy(x => x.CourseSection.Semester.AcademicYear).Asc
                //.OrderBy(x => x.CourseSection.Semester.SemesterNo).Asc
                //.OrderBy(x => x.CourseSection.ClassLevelSection.ClassLevel.LevelNo).Asc
                                                .List();

            return courseSectionTeacher
                    .Where(x => x.Classroom.School.ID == school.ID)
                    .OrderBy(x => x.Classroom.Semester.AcademicYear)
                    .OrderBy(x => x.Classroom.Semester.SemesterNo)
                    .OrderBy(x => x.Classroom.ClassLevelSection.ClassLevel.LevelNo).ToList();
        }
    }
}