using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iSISModel;

namespace iSIS.Website.Models
{
    public class InitializeData
    {
        #region --- School ---
        public static School GetSchool(int id)
        {
            return new School
            {
                ID = id,
                CurrentName = new OrgName
                {
                    ID = 1,
                    Title = new MultilingualString("th-TH", "โรงเรียน A", "en-US", "School A"),
                },
            };
        }
        #endregion
        #region --- Classroom ---
        public static List<Classroom> GetClassrooms()
        {
            return new List<Classroom>
            {
                GetClassroom(1),
                GetClassroom(2),
                GetClassroom(3),
            };
        }

        public static Classroom GetClassroom(int id)
        {
            return new Classroom
            {
                ID = id,
                Semester = GetSemester(1),
                Room = GetRoom(id),
            };
        }
        #endregion
        #region --- ClassLevel ---
        public static ClassLevelSection GetClassLevelSection(int id, int roomNo)
        {
            return new ClassLevelSection
            {
                ID = id,
                School = GetSchool(1),
                Classrooms = GetClassrooms(),
                //ClassLevel = GetClassLevel(1),
                Title = new MultilingualString("th-TH", string.Format("ป.{0}/{1}", id, roomNo)),
            };
        }

        public static ClassLevel GetClassLevel(int id)
        {
            return new ClassLevel
            {
                ID = id,
                LevelNo = id,
                Title = new MultilingualString("th-TH", "ป." + id),
            };
        }
        #endregion
        #region --- Physical Room ---
        public static List<PhysicalRoom> GetRooms()
        {
            return new List<PhysicalRoom>
            {
                GetRoom(1),
                GetRoom(2),
                GetRoom(3)
            };
        }

        public static PhysicalRoom GetRoom(int id)
        {
            return new PhysicalRoom
            {
                ID = id,
                RoomNo = "10" + id,
                BuildingTitle = new MultilingualString("th-TH", "อาคาร A", "en-US", "Building A"),
                School = GetSchool(1),
                EffectivePeriod = new DateTimeRange(DateTime.Now, DateTime.Now.AddYears(2)),
            };
        }
        #endregion
        #region --- Semester ---
        public static Semester GetSemester(int id)
        {
            return new Semester
            {
                ID = id,
                SemesterNo = id,
            };
        }
        #endregion
    }
}