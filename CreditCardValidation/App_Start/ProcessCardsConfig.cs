using CreditCardValidation.DAL;
using CreditCardValidation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using System.Web;

namespace CreditCardValidation.App_Start
{
    public class ProcessCardsConfig
    {
        public static void ScheduleProcessCards()
        {
            int interval = int.Parse(ConfigurationManager.AppSettings["JobIntervalInMilliseconds"]);

            Timer aTimer = new Timer(interval);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            int CardsToProcessPerJob = int.Parse(ConfigurationManager.AppSettings["CardsToProcessPerJob"]);

            CreditCardContext db = new CreditCardContext();

            var cardsToProcess = db.Cards.SqlQuery("select * from card where processed = 0");

            foreach (Card card in cardsToProcess.Take(CardsToProcessPerJob))
            {
                card.Processed = true;
                card.Lastmodified = DateTime.Now;
                db.Entry(card).State = EntityState.Modified;
            }

            db.SaveChanges();         
        }
    }
}