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
            if (!ModelState.IsValid) return View(trial);

            var service = CreateTrialService();

            if (service.CreateTrial(trial))
            {
                TempData["SaveResult"] = "Your trial was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Trial could not be created.");
            return View(trial);
           

        }

        public ActionResult Details(int id)
        {
            var svc = CreateTrialService();
            var trial = svc.GetTrialById(id);

            return View(trial);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTrialService();
            var detail = service.GetTrialById(id);
            var trial =
                new TrialEdit
                {
                    TrialId = detail.TrialId,
                    FoodId = detail.FoodId,
                    Comment = detail.Comment,
                    DateTime = detail.DateTime,
                    NumberOfDays = detail.NumberOfDays,
                    MedicalIntervention = detail.MedicalIntervention,
                    Symptoms = detail.Symptoms,
                    ReactionType = detail.ReactionType,
                    IsSafe = detail.IsSafe
                };
            return View(trial);
        }

        private TrialService CreateTrialService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrialService(userId);
            return service;
        }
    }
}