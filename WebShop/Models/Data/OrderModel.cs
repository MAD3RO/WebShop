using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebShop.Enums;

namespace WebShop.Models.Data
{
    [Table("tblOrders")]
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public OrderStatus Status { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime? CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel Users { get; set; }
    }
}