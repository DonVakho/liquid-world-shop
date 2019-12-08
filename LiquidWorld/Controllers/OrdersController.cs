using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LiquidWorld.Data.Models;
using LiquidWorld.Models;

namespace LiquidWorld.Controllers
{
    public class OrdersController : Controller
    {
        private MyDbContext db = new MyDbContext();

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,FirstName,LastName,AddressLine1,AddressLine2,ZipCode,State,Country,PhoneNumber,Email,OrderTotal,OrderPlaced")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public ActionResult CheckoutComplete()
        {
            var items = db.ShoppingCartItems.ToList();
            db.ShoppingCartItems.RemoveRange(items);
            db.SaveChanges();
            ViewBag.CheckoutCompleteMessage = "Thanks for your order!";
            return View();
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
