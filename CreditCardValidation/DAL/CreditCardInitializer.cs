using CreditCardValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardValidation.DAL
{
    public class CreditCardInitializer : System.Data.Entity.DropCreateDatabaseAlways<CreditCardContext> // DropCreateDatabaseIfModelChanges<CreditCardContext>
    {

        protected override void Seed(CreditCardContext context)
        {
            var cardProviders = new List<CardProvider>
            {
            new CardProvider{Description="VISA", ValidationRegex=@"\d+", CreatedDate=DateTime.Parse("2002-01-01"), Lastmodified=DateTime.Parse("2002-01-01")},
            new CardProvider{Description="Master Card", ValidationRegex=@"\d+", CreatedDate=DateTime.Parse("2002-01-01"), Lastmodified=DateTime.Parse("2002-01-01")}
            };

            cardProviders.ForEach(c => context.CardProviders.Add(c));
            context.SaveChanges();

            var cards = new List<Card>
            {
            new Card{CardNumber="12345678", CardProviderID=1, Processed=false, CreatedDate=DateTime.Parse("2002-01-01"), Lastmodified=DateTime.Parse("2002-01-01")},
            new Card{CardNumber="12345679", CardProviderID=1, Processed=false, CreatedDate=DateTime.Parse("2002-01-01"), Lastmodified=DateTime.Parse("2002-01-01")}
            };

            cards.ForEach(c => context.Cards.Add(c));
            context.SaveChanges();
        }
    }
}