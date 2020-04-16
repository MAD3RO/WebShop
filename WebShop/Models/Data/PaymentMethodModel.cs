using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShop.Models.Data
{
    [Table("tblPaymentMethods")]
    public class PaymentMethodModel
    {
        [Key]
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; }
    }
}