using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CreditCardValidation.Models
{
    public class CardProvider
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string ValidationRegex { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Lastmodified { get; set; }
        
    }
}