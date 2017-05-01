using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ACETreasureHunt.DAL;
using ACETreasureHunt.Models;
using System.Data.Entity.Validation;

namespace ACETreasureHunt.Controllers
{
    public class TeamController : Controller
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new ACEContext());

        // GET: Team
       
        public ActionResult Index()
        {
            IEnumerable<Team> GameTeams = unitOfWork.Teams.GetAll();
            return View(GameTeams);
        }

        // GET: Team/Create
        [Authorize]
        public ActionResult Create()
        {
            IEnumerable<Event> List = unitOfWork.Events.GetAll();
            ViewBag.EventID = new SelectList(List, "Id", "Name");
            Team team = new Team();
            return View(team);
        }

        // POST: Team/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Team team)
        {
            try
            {
                unitOfWork.Teams.Add(team);
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

        // GET: Team/Edit/5
        [Authorize]
        public ActionResult Edit(Team aceTeam)
        {
            IEnumerable<Event> List = unitOfWork.Events.GetAll();
            Team EventTeam = unitOfWork.Teams.Get(aceTeam.Id);
            ViewBag.EventID = new SelectList(List, "Id", "Name", EventTeam.EventID);
            return View(EventTeam);
        }

        // POST: Team/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, Team aceTeam)
        {
            try
            {
                // TODO: Add update logic here
                Team team = unitOfWork.Teams.Get(aceTeam.Id);
                UpdateModel(team);
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

        // GET: Team/Delete/5
        [Authorize]
        public ActionResult Delete(Team aceTeam)
        {
            Team EventTeam = unitOfWork.Teams.Get(aceTeam.Id);
            return View(EventTeam);
        }

        // POST: Staff/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, Team aceTeam)
        {
            try
            {
                Team team = unitOfWork.Teams.Get(aceTeam.Id);
                unitOfWork.Teams.Remove(team);
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
