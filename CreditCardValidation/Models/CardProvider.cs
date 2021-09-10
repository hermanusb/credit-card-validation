using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CreditCardValidation.Models
{
    public class CardProvider
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }

        [Display(Name = "Validation Regular Expression")]
        [Required(ErrorMessage = "Please enter regex")]
        public string ValidationRegex { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime Lastmodified { get; set; }
        
    }
}