using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models.Data;

namespace WebShop.Models.ViewModels.Shop
{
    public class OrderVM
    {
        public OrderVM()
        {
        }
        public OrderVM(OrderModel row)
        {
            OrderId = row.OrderId;
            UserId = row.UserId;
            CreatedAt = row.CreatedAt;
            Status = row.Status;
            PaymentMethod = row.PaymentMethod;
        }

        public int OrderId { get; set; }

        public int UserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string Status { get; set; }

        public string PaymentMethod { get; set; }
    }
}