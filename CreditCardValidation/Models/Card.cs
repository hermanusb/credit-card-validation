using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardValidation.Models
{
    public class Card
    {
        public int ID { get; set; }
        public bool Processed { get; set; }
        public string CardNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Lastmodified { get; set; }

        public int CardProviderID { get; set; }
        public virtual CardProvider CardProvider { get; set; }
    }
}