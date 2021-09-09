using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardValidation.Models
{
    public class CardProvider
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Lastmodified { get; set; }
        public bool IsDeleted { get; set; }
    }
}