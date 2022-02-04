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
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);
            var model = service.GetFoods();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodCreate food)
        {
            if (ModelState.IsValid)
            {
                return View(food);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);

            service.CreateFood(food);

            return RedirectToAction("Index");
            
        }
    }
}