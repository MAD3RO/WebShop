using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebShop.Models.Data;

namespace WebShop.Models.ViewModels.Shop
{
    public class CheckoutPartialVM
    {
        public List<PaymentMethodModel> PaymentMethod { get; set; }

        [Required(ErrorMessage = "You must accept the terms and conditions")]
        [DisplayName("Accept terms and conditions")]
        public bool AcceptTerms { get; set; }
    }
}