using FoodTrial.Models;
using FoodTrial.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrial.MVC.Controllers
{
    [Authorize]
    public class TrialController : Controller
    {
        // GET: Trial
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrialService(userId);
            var model = service.GetTrials();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrialCreate trial)
        {
            if (ModelState.IsValid)
            {
                return View(trial);
            }

            var service = CreateTrialService();
            service.CreateTrial(trial);
            return RedirectToAction("Index");

        }

        private TrialService CreateTrialService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrialService(userId);
            return service;
        }
    }
}