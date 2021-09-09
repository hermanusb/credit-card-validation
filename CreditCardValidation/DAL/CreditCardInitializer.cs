using CreditCardValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardValidation.DAL
{
    public class CreditCardInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CreditCardContext>
    {

        protected override void Seed(CreditCardContext context)
        {
            var cardProviders = new List<CardProvider>
            {
            new CardProvider{Description="VISA", Code="VISA", CreatedDate=DateTime.Parse("2002-01-01"), Lastmodified=DateTime.Parse("2002-01-01"), IsDeleted=false},
            new CardProvider{Description="Master Card", Code="MCRD", CreatedDate=DateTime.Parse("2002-01-01"), Lastmodified=DateTime.Parse("2002-01-01"), IsDeleted=false}
            };

            cardProviders.ForEach(c => context.CardProviders.Add(c));
            context.SaveChanges();

            var cards = new List<Card>
            {
            new Card{CardNumber="12345678", CardProviderID=1, Processed=false, CreatedDate=DateTime.Parse("2002-01-01"), Lastmodified=DateTime.Parse("2002-01-01"), IsDeleted=false},
            new Card{CardNumber="12345679", CardProviderID=1, Processed=false, CreatedDate=DateTime.Parse("2002-01-01"), Lastmodified=DateTime.Parse("2002-01-01"), IsDeleted=false}
            };

            cards.ForEach(c => context.Cards.Add(c));
            context.SaveChanges();
        }
    }
}