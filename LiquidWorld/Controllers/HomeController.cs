using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiquidWorld.Data.Models;
using LiquidWorld.Models;
using LiquidWorld.ViewModels;

namespace LiquidWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext db = new MyDbContext();

        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredDrinks = db.Drinks.Where(p => p.IsPreferredDrink.Equals(true))
            };

            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "We sell best drinks at lowest prices.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us if you have any question or issue, our 24-hour technical assistance grout will answer immediately.";

            return View();
        }
        
    }
}