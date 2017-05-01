using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACETreasureHunt.DAL;
using ACETreasureHunt.Models;
using System.Data.Entity.Validation;

namespace ACETreasureHunt.Controllers
{
    public class StaffController : Controller
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new ACEContext());
        // GET: Staff
        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<Staff> GameStaffs = unitOfWork.Staffs.GetAll();
            return View(GameStaffs);
        }

        // GET: PitStops/Details/5
        public ActionResult Details(Staff aceStaff)
        {
            Staff EventStaff = unitOfWork.Staffs.Get(aceStaff.Id);
            return View(EventStaff);
        }

        // GET: Staff/Create
        [Authorize]
        public ActionResult Create()
        {
            IEnumerable<Event> List = unitOfWork.Events.GetAll();
            ViewBag.EventID = new SelectList(List, "Id", "Name");
            Staff staff = new Staff();
            return View(staff);
        }

        // POST: Staff/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            try
            {
                unitOfWork.Staffs.Add(staff);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            catch(Exception e)
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

        // GET: Staff/Edit/5
        [Authorize]
        public ActionResult Edit(Staff aceStaff)
        {
            IEnumerable<Event> List = unitOfWork.Events.GetAll();
            Staff EventStaff = unitOfWork.Staffs.Get(aceStaff.Id);
            ViewBag.EventID = new SelectList(List, "Id", "Name", EventStaff.EventID);
            return View(EventStaff);
        }

        // POST: Staff/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id,Staff aceStaff)
        {
            try
            {
                // TODO: Add update logic here
                Staff staff = unitOfWork.Staffs.Get(aceStaff.Id);
                UpdateModel(staff);
                unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            catch(Exception e)
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

        // GET: Staff/Delete/5
        public ActionResult Delete(Staff aceStaff)
        {
            Staff EventStaff = unitOfWork.Staffs.Get(aceStaff.Id);
            return View(EventStaff);
        }
        
        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Staff aceStaff)
        {
            try
            {
                Staff staff = unitOfWork.Staffs.Get(aceStaff.Id);
                unitOfWork.Staffs.Remove(staff);
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
    }
}
