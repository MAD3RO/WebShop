using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Enums
{
    public enum PaymentMethod
    {
        [Display(Name = "Cash on Delivery")]
        Cash,
        [Display(Name = "PayPal System")]
        Paypal,
        [Display(Name = "Direct Bank Transfer")]
        Direct
    }
}