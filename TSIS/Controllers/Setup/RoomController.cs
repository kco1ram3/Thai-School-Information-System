using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using TSIS.Models;
using TSIS.Filters;
using TSIS.Classes;

namespace TSIS.Controllers.Setup
{
    [UserFilterAuthorizeAttribute]
    public class RoomController : BaseController
    {
        // GET: Room
        public ActionResult Index()
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.PhysicalRoom> room = (from n in (IList<iSISModel.PhysicalRoom>)CacheManager.GetCache(CacheManager.CacheName.Room)
                                                  where n.School.ID == school.ID
                                                  select n).ToList();
            return View(room);
        }

        public ActionResult GridViewRoomData()
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.PhysicalRoom> room = (from n in (IList<iSISModel.PhysicalRoom>)CacheManager.GetCache(CacheManager.CacheName.Room)
                                                  where n.School.ID == school.ID
                                                  select n).ToList();
            return PartialView("_GridViewRoomData", room);
        }

        [HttpPost]
        public ActionResult GridViewRoomDataAddNewOrUpdate(iSISModel.PhysicalRoom room, FormCollection collection)
        {
            iSISModel.PhysicalRoom update = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.PhysicalRoom>()
                                           .Where(x => x.ID == room.ID)
                                           .SingleOrDefault();

            Int64 classLevelID = (!string.IsNullOrEmpty(collection["ComboBoxClassLevel_VI"])) ? Int64.Parse(collection["ComboBoxClassLevel_VI"]) : 0;

            if (update == null)
            {
                update = new iSISModel.PhysicalRoom();
                update.School = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
                update.EffectivePeriod = new iSISModel.DateTimeRange(DateTime.Today);
            }
            update.ClassLevel = ModelsRepository.GetClassLevelByID(classLevelID);
            if (update.BuildingTitle == null)
            {
                update.BuildingTitle = ModelsRepository.GetTextBoxMultiLanguages(collection, "BuildingTitle");
            }
            else
            {
                update.BuildingTitle.AddOrReplace(ModelsRepository.GetTextBoxMultiLanguages(collection, "BuildingTitle"));
            }
            update.RoomNo = room.RoomNo;

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
            return PartialView("_GridViewRoomData", RoomData());
        }

        [HttpPost]
        public ActionResult GridViewRoomDataDelete(long ID)
        {
            iSISModel.PhysicalRoom room = base.Context.PersistenceSession
                                           .QueryOver<iSISModel.PhysicalRoom>()
                                           .Where(x => x.ID == ID)
                                           .SingleOrDefault();

            room.EffectivePeriod.To = DateTime.Today;

            using (ITransaction tran = base.Context.PersistenceSession.BeginTransaction())
            {
                try
                {
                    room.Persist(base.Context);

                    tran.Commit();
                }
                catch (Exception exc)
                {
                    tran.Rollback();
                    throw exc;
                }
            }
            return PartialView("_GridViewRoomData", RoomData());
        }

        private IList<iSISModel.PhysicalRoom> RoomData()
        {
            iSISModel.School school = (iSISModel.School)SessionManager.GetSession(this, SessionManager.SessionName.CurrentSchool);
            IList<iSISModel.PhysicalRoom> room = base.Context.PersistenceSession
                                .QueryOver<iSISModel.PhysicalRoom>()
                //.Where(x => x.School == school)
                                .And(x => x.EffectivePeriod.To > DateTime.Today)
                                .List();
            CacheManager.SetCache(CacheManager.CacheName.Room, room);

            return room.Where(x => x.School.ID == school.ID).ToList();
        }
    }
}