using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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
            return View(db.CardProviders.ToList());
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
        public ActionResult Create([Bind(Include = "ID,Code,Description,CreatedDate,Lastmodified,IsDeleted")] CardProvider cardProvider)
        {
            if (ModelState.IsValid)
            {
                db.CardProviders.Add(cardProvider);
                db.SaveChanges();
                return RedirectToAction("Index");
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
        public ActionResult Edit([Bind(Include = "ID,Code,Description,CreatedDate,Lastmodified,IsDeleted")] CardProvider cardProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardProvider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
