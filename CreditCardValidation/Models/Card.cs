using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreditCardValidation.Models
{
    public class Card
    {
        public int ID { get; set; }
        public bool Processed { get; set; }

        [Display(Name = "Card Number")]
        [Required(ErrorMessage = "Please enter card number")]
        public string CardNumber { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime Lastmodified { get; set; }

        public int CardProviderID { get; set; }
        public virtual CardProvider CardProvider { get; set; }
    }
}