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
    public class MedicineController : Controller
    {
        // GET: Medicine
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
        public ActionResult Create(MedicineCreate medicine)
        {
            if (ModelState.IsValid)
            {
                return View(medicine);
            }

            var service = CreateMedicineService();
            service.CreateMedicine(medicine);
            return RedirectToAction("Index");


        }

        private MedicineService CreateMedicineService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MedicineService(userId);
            return service;
        }
    }
}