using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACETreasureHunt.Models;
using ACETreasureHunt.DAL;
using System.Data.Entity.Validation;

namespace ACETreasureHunt.Controllers
{
    public class EventController : Controller
    {

        IUnitOfWork unitOfWork = new UnitOfWork(new ACEContext());
        // GET: Event
        
        public ActionResult Index()
        {
            IEnumerable<Event> GameEvents = unitOfWork.Events.GetAllEvents();
            return View(GameEvents);
        }

        // GET: Event/Details/5
        
        public ActionResult Details(Event aceEvent)
        {
            
            IEnumerable<Team> Teams = unitOfWork.Teams.GetAll();
            List<Team> ThisEventTeams = new List<Team>();
            foreach (var item in Teams)
            {
                if (aceEvent.Id == item.EventID)
                {
                    ThisEventTeams.Add(item);
                }
            }

            IEnumerable<Staff> Staffs = unitOfWork.Staffs.GetAll();
            List<Staff> ThisEventStaffs = new List<Staff>();
            foreach (var item in Staffs)
            {
                if (aceEvent.Id == item.EventID)
                {
                    ThisEventStaffs.Add(item);
                }
            }

            IEnumerable<PitStop> PitStops = unitOfWork.PitStops.GetAll();
            List<PitStop> ThisEventPitStops = new List<PitStop>();
            foreach (var item in PitStops)
            {
                if (aceEvent.Id == item.EventID)
                {
                    ThisEventPitStops.Add(item);
                }
            }

            ViewBag.MyList = ThisEventTeams;
            ViewBag.MyList2 = ThisEventStaffs;
            ViewBag.StaffSize = ThisEventStaffs.Count;
            ViewBag.MyList3 = ThisEventPitStops;
            ViewBag.EventLat = aceEvent.StartLatitude;
            ViewBag.EventLong = aceEvent.StartLongitude;

            List<double> StaffLatList = new List<double>();
            List<double> StaffLongList = new List<double>();            
            for (int i = 0; i < ThisEventStaffs.Count; ++i) {
                
                StaffLatList.Add(ThisEventStaffs[i].Latitude);
                StaffLongList.Add(ThisEventStaffs[i].Longitude);
            }
            ViewBag.Staff1 = ThisEventStaffs[0].Name;
            ViewBag.Staff2 = ThisEventStaffs[1].Name;
            ViewBag.Staff3 = ThisEventStaffs[2].Name;

            ViewBag.StaffLatitudeList = StaffLatList;
            ViewBag.StaffLongitudeList = StaffLongList;

            return View(ThisEventTeams);
        }

        // GET: Event/Create
        [Authorize]
        public ActionResult Create()
        {
            Event GameEvent = new Event();
            return View(GameEvent);
        }

        // POST: Event/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Event aceEvent)
        {
            try
            {
                // TODO: Add insert logic here
                unitOfWork.Events.Add(aceEvent);
                unitOfWork.Complete();
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                if (e.GetType() != typeof(DbEntityValidationException))
                {
                    if (this.HttpContext.IsDebuggingEnabled)
                    {
                        ModelState.AddModelError(string.Empty, e.ToString());
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Some technical error happened.");
                    }
                }
                return View();
            }
        }

        // GET: Event/Edit/5
        [Authorize]
        public ActionResult Edit(Event aceEvent)
        {
            Event editEvent = unitOfWork.Events.Get(aceEvent.Id);
            IEnumerable<Team> Teams = unitOfWork.Teams.GetAll();
            List<Team> ThisEventTeams = new List<Team>();
            foreach (var item in Teams)
            {
                if (aceEvent.Id == item.EventID)
                {
                    ThisEventTeams.Add(item);
                }
            }

            IEnumerable<Staff> Staffs = unitOfWork.Staffs.GetAll();
            List<Staff> ThisEventStaffs = new List<Staff>();
            foreach (var item in Staffs)
            {
                if (aceEvent.Id == item.EventID)
                {
                    ThisEventStaffs.Add(item);
                }
            }

            IEnumerable<PitStop> PitStops = unitOfWork.PitStops.GetAll();
            List<PitStop> ThisEventPitStops = new List<PitStop>();
            foreach (var item in PitStops)
            {
                if (aceEvent.Id == item.EventID)
                {
                    ThisEventPitStops.Add(item);
                }
            }

            ViewBag.MyList = ThisEventTeams;
            ViewBag.MyList2 = ThisEventStaffs;
            ViewBag.MyList3 = ThisEventPitStops;
            ViewBag.EventLat = aceEvent.StartLatitude;
            ViewBag.EventLong = aceEvent.StartLongitude;
            return View(editEvent);
        }

        // POST: Event/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, Event aceEvent)
        {
            try
            {
                // TODO: Add update logic here
                Event modifyEvent = unitOfWork.Events.Get(aceEvent.Id);
                UpdateModel(modifyEvent);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
