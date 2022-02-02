using FoodTrial.Models;
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
            var model = new TrialListItem[0];
            return View(model);
        }
    }
}