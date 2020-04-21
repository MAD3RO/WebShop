using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShop.Models.Data
{
    [Table("tblCartDetails")]
    public class CartDetailsModel
    {
        [Key]
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("CartId")]
        public virtual CartModel Carts { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductModel Products { get; set; }
    }
}