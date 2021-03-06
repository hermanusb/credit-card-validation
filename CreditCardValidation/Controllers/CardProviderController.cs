using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CreditCardValidation.DAL;
using CreditCardValidation.Models;

namespace CreditCardValidation.Controllers
{
    public class CardProviderController : Controller
    {
        private CreditCardContext db = new CreditCardContext();

        // GET: CardProvider
        public ActionResult Index()
        {
            //return View(db.CardProviders.ToList());
            return View(db.CardProviders.ToList());
        }

        public ActionResult List(int? id)
        {
            if (id == null)
            {
                return Json(db.CardProviders.ToList(), JsonRequestBehavior.AllowGet);
            }

            CardProvider cardProvider = db.CardProviders.Find(id);
            if (cardProvider == null)
            {
                return HttpNotFound();
            }

            return Json(cardProvider, JsonRequestBehavior.AllowGet);
        }

        // GET: CardProvider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardProvider cardProvider = db.CardProviders.Find(id);
            if (cardProvider == null)
            {
                return HttpNotFound();
            }
            return View(cardProvider);
        }

        // GET: CardProvider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CardProvider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description,ValidationRegex")] CardProvider cardProvider)
        {
            if (ModelState.IsValid)
            {
                cardProvider.CreatedDate = DateTime.Now;
                cardProvider.Lastmodified = DateTime.Now;

                db.CardProviders.Add(cardProvider);
                db.SaveChanges();

                return Json(new { redirectToUrl = Url.Action("Index", "CardProvider") });
            }

            return View(cardProvider);
        }

        // GET: CardProvider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CardProvider cardProvider = db.CardProviders.Find(id);
            if (cardProvider == null)
            {
                return HttpNotFound();
            }

            return View(cardProvider);
        }

        // POST: CardProvider/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,ValidationRegex,CreatedDate")] CardProvider cardProvider)
        {
            if (ModelState.IsValid)
            {
                cardProvider.Lastmodified = DateTime.Now;
                db.Entry(cardProvider).State = EntityState.Modified;
                db.SaveChanges();

                return Json(new { redirectToUrl = Url.Action("Index", "CardProvider") });
                //return RedirectToAction("Index", "CardProvider");
            }
            return View(cardProvider);
        }

        // GET: CardProvider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardProvider cardProvider = db.CardProviders.Find(id);
            if (cardProvider == null)
            {
                return HttpNotFound();
            }
            return View(cardProvider);
        }

        // POST: CardProvider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CardProvider cardProvider = db.CardProviders.Find(id);
            db.CardProviders.Remove(cardProvider);
            db.SaveChanges();

            return Json(new { redirectToUrl = Url.Action("Index", "CardProvider") });
            //return RedirectToAction("Index");
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
