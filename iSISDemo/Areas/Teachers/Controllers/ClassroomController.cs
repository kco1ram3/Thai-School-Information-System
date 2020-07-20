using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iSISDemo.Controllers;
using NHibernate;
using iSISDemo.Models;
using iSISDemo.Filters;
using iSISDemo.Classes;

namespace iSISDemo.Areas.Teachers.Controllers
{
    [UserFilterAuthorizeAttribute]
    public class ClassroomController : BaseController
    {
        // GET: Teachers/Classroom
        #region Classroom
        public ActionResult Index()
        {
            return View(getTeacherList());
        }

        public ActionResult GridViewClassroomTeacherList()
        {
            return PartialView("_GridViewClassroomTeacherList", getTeacherList());
        }

        private IList<iSISModel.Teacher> getTeacherList()
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.Teacher> teacher = base.Context.PersistenceSession
                                               .QueryOver<iSISModel.Teacher>()
                                               .Where(t => t.EffectivePeriod.To > DateTime.Today)
                                               .And(t => t.School == school)
                                               .List();
            return teacher;
        }
        #endregion

        #region ClassroomTeacher
        public ActionResult ClassroomTeacher(int id = 0)
        {
            if (id == 0)
            {
                iSISModel.User user = (iSISModel.User)SessionManager.GetSession(this, SessionManager.SessionName.CurrentUser);
                id = user.Person.ID;
            }
            ViewData["id"] = id;
            return View(getClassroomTeacherList(id));
        }

        public ActionResult GridViewClassroomList(int id)
        {
            ViewData["id"] = id;
            return PartialView("_GridViewClassroomList", getClassroomTeacherList(id));
        }

        private IList<iSISModel.ClassroomTeacher> getClassroomTeacherList(int id)
        {
            iSISModel.Person person = base.Context.PersistenceSession
                                 .QueryOver<iSISModel.Person>()
                                 .Where(x => x.ID == id)
                                 .SingleOrDefault();

            if (person != null)
            {
                ViewData["PersonName"] = person.CurrentName.ToString(CookieManager.GetCookie(this, CookieManager.CookieName.CurrentLanguage));
            }

            iSISModel.Teacher teacher = base.Context.PersistenceSession
                                 .QueryOver<iSISModel.Teacher>()
                                 .Where(x => x.Person.ID == id)
                                 .SingleOrDefault();

            IList<iSISModel.ClassroomTeacher> classroomTeacher = base.Context.PersistenceSession
                .QueryOver<iSISModel.ClassroomTeacher>()
                .Where(x => x.Teacher.ID == teacher.ID)
                .And(x => x.EffectivePeriod.To > DateTime.Today)
                .List();

            return classroomTeacher;
        }
        #endregion

        #region ClassroomStudent
        public ActionResult ClassroomStudent(int id)
        {
            ViewData["classroomID"] = id;
            iSISModel.Classroom classroom = getClassroom(id);
            ViewData["Classroom"] = classroom;
            ViewData["ClassLevel"] = ((IList<iSISModel.ClassLevel>)CacheManager.GetCache(CacheManager.CacheName.ClassLevel)).Where(x => x.LevelNo >= classroom.ClassLevelSection.ClassLevel.LevelNo).ToList();

            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.Semester> semester = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.Semester>()
                                                .Where(x => x.School == school)
                                                .And(x => x.EffectivePeriod.To > DateTime.Today)
                                                .And(x => x.AcademicYear == classroom.Semester.AcademicYear)
                                                .List();

            bool LastSemesterOfYear = false;
            if (semester.Max(x => x.SemesterNo) == classroom.Semester.SemesterNo)
            {
                LastSemesterOfYear = true;
            }
            ViewData["IsLastSemesterOfYear"] = LastSemesterOfYear;

            return View(getClassroomStudentList(id));
        }

        public ActionResult GridViewClassroomStudentList(int classroomID)
        {
            ViewData["IsCallback"] = true;
            ViewData["classroomID"] = classroomID;
            return PartialView("_GridViewClassroomStudentList", getClassroomStudentList(classroomID));
        }

        [HttpPost]
        public ActionResult ClassroomStudent(int id, FormCollection collection)
        {
            string selectedCheckboxGraduate = collection["selectedCheckboxGraduate"];
            string selectedCheckbox = collection["selectedCheckbox"];
            Int64 classLevelID = (!string.IsNullOrEmpty(collection["ComboBoxClassLevel_VI"])) ? Int64.Parse(collection["ComboBoxClassLevel_VI"]) : 0;
            Int64 roomID = (!string.IsNullOrEmpty(collection["ComboBoxRoom_VI"])) ? Int64.Parse(collection["ComboBoxRoom_VI"]) : 0;
            iSISModel.ClassLevel classLevel = ModelsRepository.GetClassLevelByID(classLevelID);
            iSISModel.PhysicalRoom room = ModelsRepository.GetRoomByID(roomID);

            iSISModel.CurriculumFramework curriculumFramework = base.Context.PersistenceSession
                                                                .QueryOver<iSISModel.CurriculumFramework>()
                                                                .Where(x => x.EffectivePeriod.To > DateTime.Today)
                                                                .Take(1).SingleOrDefault();

            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.Curriculum> curriculum = base.Context.PersistenceSession
                                              .QueryOver<iSISModel.Curriculum>()
                                              .Where(x => x.CurriculumFramework == curriculumFramework)
                                              .And(x => x.School == school)
                                              //.And(x => x.StartingClassLevel.LevelNo <= classLevel.LevelNo)
                                              //.And(x => x.EndingClassLevel.LevelNo >= classLevel.LevelNo)
                                              .And(x => x.EffectivePeriod.To > DateTime.Today)
                                              .List();
            iSISModel.Curriculum c = curriculum.FirstOrDefault(x => x.StartingClassLevel.LevelNo <= classLevel.LevelNo && x.EndingClassLevel.LevelNo >= classLevel.LevelNo);
            IList<iSISModel.CurriculumCourse> curriculumCourse = null;
            if (c != null)
            {
                curriculumCourse = c.CurriculumCourses;
                if (curriculumCourse != null)
                {
                    curriculumCourse = curriculumCourse.Where(x => x.ForClassLevel.LevelNo == classLevel.LevelNo).ToList();
                }
            }
            string[] value = null;
            if (!string.IsNullOrEmpty(selectedCheckboxGraduate))
            {
                value = selectedCheckboxGraduate.Split(',');
            }
            else 
            {
                value = selectedCheckbox.Split(',');
            }

            foreach(string i in value) {
                if (!string.IsNullOrEmpty(selectedCheckboxGraduate))
                {
                    Graduate(long.Parse(i));
                }
                else
                {
                    UpdateOrRepeatedly(long.Parse(i), classLevel, room, curriculumCourse);
                }
            }
            return RedirectToAction("ClassroomStudent", new { id = id });
        }

        private void UpdateOrRepeatedly(long classroomStudentID, iSISModel.ClassLevel classLevel, iSISModel.PhysicalRoom room, IList<iSISModel.CurriculumCourse> curriculumCourse)
        {
            iSISModel.ClassroomStudent update = base.Context.PersistenceSession
                .QueryOver<iSISModel.ClassroomStudent>()
                .Where(x => x.ID == classroomStudentID)
                .SingleOrDefault();

            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.Semester> semester = base.Context.PersistenceSession
                                                .QueryOver<iSISModel.Semester>()
                                                .Where(x => x.School == school)
                                                .And(x => x.EffectivePeriod.To > DateTime.Today)
                                                .And(x => x.AcademicYear == update.Classroom.Semester.AcademicYear + 1)
                                                .OrderBy(x => x.AcademicYear).Asc
                                                .OrderBy(x => x.SemesterNo).Asc
                                                .List();

            if (semester.Count > 0)
            {
                iSISModel.Student student = new iSISModel.Student
                {
                    EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today),
                    IDNo = update.Student.IDNo,
                    Person = update.Student.Person,
                    Remark = update.Student.Remark,
                    School = update.Student.School,
                    AdmittedClassLevel = classLevel,
                    AdmittedAcademicYear = semester[0].AcademicYear,
                    AdmittedSemester = semester[0],
                    AdmittedSemesterNo = semester[0].SemesterNo

                };

                using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
                {
                    try
                    {
                        update.Student.EffectivePeriod.To = DateTime.Today;
                        update.Student.Persist(base.Context);

                        student.Persist(base.Context);

                        foreach (iSISModel.Semester s in semester)
                        {
                            iSISModel.ClassLevelSection classLevelSection = base.Context.PersistenceSession
                                                                            .QueryOver<iSISModel.ClassLevelSection>()
                                                                            .Where(x => x.School == school)
                                                                            .And(x => x.EffectivePeriod.To > DateTime.Today)
                                                                            .And(x => x.ClassLevel == classLevel)
                                                                            .And(x => x.Semester == s)
                                                                            .SingleOrDefault();

                            iSISModel.Classroom classroom = base.Context.PersistenceSession
                                                            .QueryOver<iSISModel.Classroom>()
                                                            .Where(x => x.ClassLevelSection == classLevelSection)
                                                            .And(x => x.Room == room)
                                                            .And(x => x.School == school)
                                                            .And(x => x.Semester == s)
                                                            .SingleOrDefault();
                            if (classroom == null)
                            {
                                classroom = new iSISModel.Classroom
                                {
                                    ClassLevelSection = classLevelSection, 
                                    Room = room, 
                                    School = school, 
                                    Semester = s
                                };
                                classroom.Persist(base.Context);
                            }

                            iSISModel.ClassroomStudent classroomStudent = new iSISModel.ClassroomStudent
                            {
                                Classroom = classroom,
                                Student = student,
                                EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today)
                            };
                            classroomStudent.Persist(base.Context);

                            foreach (iSISModel.CurriculumCourse cc in curriculumCourse.Where(x => x.ForSemesterNo == s.SemesterNo).ToList())
                            {
                                if (cc.Course != null)
                                {
                                    iSISModel.CourseSection courseSection = base.Context.PersistenceSession
                                                            .QueryOver<iSISModel.CourseSection>()
                                                            .Where(x => x.ClassLevelSection == classLevelSection)
                                                            .And(x => x.Room == room)
                                                            .And(x => x.School == school)
                                                            .And(x => x.Semester == s)
                                                            .And(x => x.Course == cc.Course)
                                                            .SingleOrDefault();
                                    if (courseSection == null)
                                    {
                                        courseSection = new iSISModel.CourseSection
                                        {
                                            ClassLevelSection = classLevelSection,
                                            Room = room,
                                            School = school,
                                            Semester = s, 
                                            Course = cc.Course
                                        };
                                        courseSection.Persist(base.Context);
                                    }

                                    iSISModel.CourseSectionStudent courseSectionStudent = new iSISModel.CourseSectionStudent
                                    {
                                        CourseSection = courseSection,
                                        Student = student,
                                        EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today)
                                    };
                                    courseSectionStudent.Persist(base.Context);
                                }
                            }
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
        }

        private void Graduate(long classroomStudentID)
        {
            iSISModel.ClassroomStudent update = base.Context.PersistenceSession
                .QueryOver<iSISModel.ClassroomStudent>()
                .Where(x => x.ID == classroomStudentID)
                .SingleOrDefault();
            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    update.Student.EffectivePeriod.To = DateTime.Today;
                    update.Student.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
        }

        private IList<iSISModel.ClassroomStudent> getClassroomStudentList(int classroomID)
        {
            IList<iSISModel.ClassroomStudent> classroomStudent = base.Context.PersistenceSession
                .QueryOver<iSISModel.ClassroomStudent>()
                .Where(x => x.Classroom.ID == classroomID)
                .And(x => x.EffectivePeriod.To > DateTime.Today)
                .List();

            return classroomStudent;
        }

        private iSISModel.Classroom getClassroom(int classroomID)
        {
            iSISModel.Classroom classroom = base.Context.PersistenceSession
                .QueryOver<iSISModel.Classroom>()
                .Where(x => x.ID == classroomID)
                .SingleOrDefault();

            return classroom;
        }
        #endregion
    }
}