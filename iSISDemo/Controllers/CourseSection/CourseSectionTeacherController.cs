using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using iSISDemo.Models;
using iSISDemo.Filters;
using iSISDemo.Classes;

namespace iSISDemo.Controllers.CourseSection
{
    [UserFilterAuthorizeAttribute]
    public class CourseSectionTeacherController : BaseController
    {
        // GET: CourseSectionTeacher
        public ActionResult Index()
        {
            return View(CourseSectionTeacherData());
        }

        public ActionResult GridViewCourseSectionTeacherData()
        {
            return PartialView("_GridViewCourseSectionTeacherData", CourseSectionTeacherData());
        }

        [HttpPost]
        public ActionResult GridViewCourseSectionTeacherDataAddNewOrUpdate(iSISModel.CourseSectionTeacher courseSectionTeacher, FormCollection collection)
        {
            CreateOrUpdate(courseSectionTeacher, collection);
            return PartialView("_GridViewCourseSectionTeacherData", CourseSectionTeacherData());
        }

        [HttpPost]
        public ActionResult GridViewCourseSectionTeacherDataDelete(long ID)
        {
            iSISModel.CourseSectionTeacher courseSectionTeacher = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.CourseSectionTeacher>()
                                          .Where(x => x.ID == ID)
                                          .SingleOrDefault();

            courseSectionTeacher.EffectivePeriod.To = DateTime.Today;

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    courseSectionTeacher.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewCourseSectionTeacherData", CourseSectionTeacherData());
        }

        private void CreateOrUpdate(iSISModel.CourseSectionTeacher courseSectionTeacher, FormCollection collection)
        {
            iSISModel.CourseSectionTeacher update = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.CourseSectionTeacher>()
                                          .Where(x => x.ID == courseSectionTeacher.ID)
                                          .SingleOrDefault();

            int academicYear = (!string.IsNullOrEmpty(collection["ComboBoxAcademicYear_VI"])) ? int.Parse(collection["ComboBoxAcademicYear_VI"]) : 0;
            int semesterNo = (!string.IsNullOrEmpty(collection["ComboBoxSemester_VI"])) ? int.Parse(collection["ComboBoxSemester_VI"]) : 0;
            Int64 classLevelID = (!string.IsNullOrEmpty(collection["ComboBoxClassLevel_VI"])) ? Int64.Parse(collection["ComboBoxClassLevel_VI"]) : 0;
            Int64 courseID = (!string.IsNullOrEmpty(collection["ComboBoxCourse_VI"])) ? Int64.Parse(collection["ComboBoxCourse_VI"]) : 0;
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

            iSISModel.CourseSection courseSection = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.CourseSection>()
                                          .Where(x => x.Course.ID == courseID)
                                          .And(x => x.Semester.ID == semester.ID)
                                          .And(x => x.ClassLevelSection.ID == classLevelSection.ID)
                                          .And(x => x.Room.ID == roomID)
                                          .And(x => x.School.ID == school.ID)
                                          .SingleOrDefault();

            if (courseSection == null)
            {
                courseSection = new iSISModel.CourseSection();
                courseSection.Course = ModelsRepository.GetCourseByID(courseID);
                courseSection.Semester = semester;
                courseSection.ClassLevelSection = classLevelSection;
                courseSection.Room = ModelsRepository.GetRoomByID(roomID);
                courseSection.School = school;
            }

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    if (courseSection.ID == 0)
                    {
                        courseSection.Persist(base.Context);
                    }

                    iSISModel.CourseSectionTeacher duplicate = base.Context.PersistenceSession
                                          .QueryOver<iSISModel.CourseSectionTeacher>()
                                          .Where(x => x.CourseSection.ID == courseSection.ID)
                                          .And(x => x.Teacher.ID == teacherID)
                                          .And(x => x.EffectivePeriod.To > DateTime.Today)
                                          .And(x => x.ID != courseSectionTeacher.ID)
                                          .SingleOrDefault();

                    if (duplicate == null)
                    {
                        if (update == null)
                        {
                            update = new iSISModel.CourseSectionTeacher();
                            update.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
                        }
                        update.CourseSection = courseSection;
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

        private IList<iSISModel.CourseSectionTeacher> CourseSectionTeacherData()
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

            IList<iSISModel.CourseSectionTeacher> courseSectionTeacher = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.CourseSectionTeacher>()
                                                .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                                //.And(x => x.CourseSection.School.ID == school.ID)
                                                //.OrderBy(x => x.CourseSection.Semester.AcademicYear).Asc
                                                //.OrderBy(x => x.CourseSection.Semester.SemesterNo).Asc
                                                //.OrderBy(x => x.CourseSection.ClassLevelSection.ClassLevel.LevelNo).Asc
                                                .List();

            return courseSectionTeacher
                    .Where(x => x.CourseSection.School.ID == school.ID)
                    .OrderBy(x => x.CourseSection.Semester.AcademicYear)
                    .OrderBy(x => x.CourseSection.Semester.SemesterNo) 
                    .OrderBy(x => x.CourseSection.ClassLevelSection.ClassLevel.LevelNo).ToList();
        }
    }
}