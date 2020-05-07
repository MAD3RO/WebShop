using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Enums;

namespace WebShop.Models.ViewModels.Account
{
    public class OrdersForUserVM
    {
        public int OrderNumber { get; set; }
        public decimal Total { get; set; }
        public Dictionary<string, int> ProductsAndQty { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string PaymentMethod { get; set; }
        public OrderStatus Status { get; set; }
    }
}