using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LiquidWorld.Data.Models;
using LiquidWorld.Models;
using LiquidWorld.ViewModels;
using  LiquidWorld.Data.Interfaces;

namespace LiquidWorld.Controllers
{
    
    public class DrinkController : Controller
    {
        private readonly MyDbContext db = new MyDbContext();
        // GET: Drink
        public ActionResult Index()
        {
            var drinks = db.Drinks.Include(d => d.Category);
            return View(drinks.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }

        public ViewResult List(int category)
        {
            int _category = category;
            IEnumerable<Drink> drinks;
            int currentCategory = 0;

            if (_category == 0)
            {
                drinks = db.Drinks;
                currentCategory = 0;
            }
            else
            {
                if (_category == 1)
                    drinks = db.Drinks.Where(p => p.Category.CategoryName.Equals("Alcoholic")).OrderBy(p => p.Name);
                else
                    drinks = db.Drinks.Where(p => p.Category.CategoryName.Equals("Non-alcoholic")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new DrinksListViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCategory
            });
        }
        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Drink> drinks;

            if (string.IsNullOrEmpty(_searchString))
            {
                drinks = db.Drinks.OrderBy(p => p.DrinkId);
            }
            else
            {
                drinks = db.Drinks.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Drink/List.cshtml", new DrinksListViewModel { Drinks = drinks, CurrentCategory = 0 });
        }

    }
}
