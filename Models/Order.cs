using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Indo_Burma.Models
{
    public class Order
    {
       [Key]
       [BindNever]
       public int OrderNumber { get; set; }

        [BindNever]
        public ICollection<CartLineItem> Lines { get; set; }
        [Required(ErrorMessage = "Please enter your name:")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter a proper email address:")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a address:")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a city:")]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a Zip code:")]
        public string Zip { get; set; }

        //// Card Info to come

        public string CardName { get; set; }
        //[Required]
        public string CardNumber { get; set; }
        //[Required]
        public string ExpirationMonth { get; set; }
        //[Required]
        public string ExpirationYear { get; set; }
        //[Required]
        public string CVV { get; set; }
    }
}
