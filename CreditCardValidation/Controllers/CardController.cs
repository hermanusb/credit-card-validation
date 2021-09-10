using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using CreditCardValidation.DAL;
using CreditCardValidation.Models;

namespace CreditCardValidation.Controllers
{
    public class CardController : Controller
    {
        private CreditCardContext db = new CreditCardContext();

        // GET: Card
        public ActionResult Index()
        {
            var cards = db.Cards.Include(c => c.CardProvider);
            return View(cards.ToList());
        }

        // GET: Card/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }

            return View(card);
        }

        // GET: Card/Create
        public ActionResult Create()
        {
            ViewBag.CardProviderID = new SelectList(db.CardProviders, "ID", "Description");
            return View();
        }

        // POST: Card/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CardNumber")] Card card)
        {
            if (ModelState.IsValid)
            {
                foreach (CardProvider cardProvider in db.CardProviders)
                {
                    if (IsValidNumber(card.CardNumber, cardProvider))
                    {
                        card.CardProvider = cardProvider;
                        break;
                    }
                }

                if (card.CardProvider != null)
                {
                    card.CreatedDate = DateTime.Now;
                    card.Lastmodified = DateTime.Now;

                    db.Cards.Add(card);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            ViewBag.CardProviderID = new SelectList(db.CardProviders, "ID", "Description", card.CardProviderID);
            return View(card);
        }


        private bool IsValidNumber(string cardNumber, CardProvider cardProvider)
        {
            Regex regex = new Regex(cardProvider.ValidationRegex);
            return regex.IsMatch(cardNumber);
        }

        // GET: Card/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            ViewBag.CardProviderID = new SelectList(db.CardProviders, "ID", "Description", card.CardProviderID);
            return View(card);
        }

        // POST: Card/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Processed,CardNumber,CreatedDate,Lastmodified,IsDeleted,CardProviderID")] Card card)
        {
            if (ModelState.IsValid)
            {
                db.Entry(card).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CardProviderID = new SelectList(db.CardProviders, "ID", "Description", card.CardProviderID);
            return View(card);
        }

        // GET: Card/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // POST: Card/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Card card = db.Cards.Find(id);
            db.Cards.Remove(card);
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
