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
        public ActionResult Get()
        {
            TrialService trialService = CreateTrialService();
            var safeFoodList = trialService.GetSafeFoodList();
            return View(safeFoodList);
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
                    
                    FoodId = detail.FoodId,
                    Comment = detail.Comment,
                    DateTime = detail.DateTime,
                    NumberOfDays = detail.NumberOfDays,
                    MedicalIntervention = detail.MedicalIntervention,
                    //Symptoms = detail.Symptoms,
                    ReactionType = detail.ReactionType,
                    IsSafe = detail.IsSafe
                };
            return View(trial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TrialEdit trial)
        {
            if (!ModelState.IsValid) return View(trial);

            if (trial.TrialId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(trial);
            }

            var service = CreateTrialService();

            if (service.UpdateTrial(trial))
            {
                TempData["SaveResult"] = "Your trial was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your trial could not be updated.");
            return View(trial);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTrialService();
            var trial = svc.GetTrialById(id);

            return View(trial);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTrialService();
            service.DeleteTrial(id);
            TempData["SaveResult"] = "Your trial was deleted";
            return RedirectToAction("Index");
        }

        private TrialService CreateTrialService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrialService(userId);
            return service;
        }

        [HttpPost]
        public string SaveResults(List<int> symptoms)
        {

            if (symptoms != null)
            {
                return string.Join(",", symptoms);
            }
            else
            {
                return "No values are selected";
            }
        }
    }
}