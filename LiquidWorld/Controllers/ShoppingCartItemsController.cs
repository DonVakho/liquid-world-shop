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
using Microsoft.Ajax.Utilities;

namespace LiquidWorld.Controllers
{
    [Authorize]
    public class ShoppingCartItemsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: ShoppingCartItems
        public ActionResult Index()
        {
            return View(db.ShoppingCartItems.ToList());
        }

        // GET: ShoppingCartItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCartItem shoppingCartItem = db.ShoppingCartItems.Find(id);
            if (shoppingCartItem == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCartItem);
        }

        public ActionResult Create(int drink)
        {
            var added = false;
            var dr = db.Drinks.FirstOrDefault(p => p.DrinkId == drink);
            try
            {
                foreach (var oneItem in db.ShoppingCartItems)
                {
                    if (oneItem.Drink.Equals(dr.Name))
                    {
                        added = true;
                        oneItem.Amount++;
                        break;
                    }
                }

                if (!added)
                {
                    db.ShoppingCartItems.Add(new ShoppingCartItem {Drink = dr.Name, Amount = 1, price = dr.Price});
                }
            }

            catch (NullReferenceException)
            {

            }
            db.SaveChanges();
           return RedirectToAction("Index");

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingCartItem shoppingCartItem = db.ShoppingCartItems.Find(id);
            if (shoppingCartItem == null)
            {
                return HttpNotFound();
            }
            return View(shoppingCartItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingCartItem shoppingCartItem = db.ShoppingCartItems.Find(id);
            db.ShoppingCartItems.Remove(shoppingCartItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
