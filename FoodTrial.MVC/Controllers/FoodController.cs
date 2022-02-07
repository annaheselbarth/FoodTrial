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
            if (!ModelState.IsValid) return View(food);
            var service = CreateFoodService();
            if (service.CreateFood(food))
            {
                TempData["SaveResult"] = "Your food was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Note could not be created.");

            return View(food);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateFoodService();
            var food = svc.GetFoodById(id);

            return View(food);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFoodService();
            var detail = service.GetFoodById(id);
            var food =
                new FoodEdit
                {
                    FoodId = detail.FoodId,
                    Name = detail.Name,
                    AllergenGroup = detail.AllergenGroup,
                    FoodGroup = detail.FoodGroup,
                    Description = detail.Description
                };
                return View(food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FoodEdit food)
        {
            if (!ModelState.IsValid) return View(food);

            if(food.FoodId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(food);
            }

            var service = CreateFoodService();

            if (service.UpdateFood(food))
            {
                TempData["SaveResult"] = "Your food was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your food could not be updated.");
            return View(food);
        }
        
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFoodService();
            var food = svc.GetFoodById(id);

            return View(food);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFoodService();
            service.DeleteFood(id);
            TempData["SaveResult"] = "Your food was deleted";
            return RedirectToAction("Index");
        }

        private FoodService CreateFoodService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);
            return service;
        }
    }
}