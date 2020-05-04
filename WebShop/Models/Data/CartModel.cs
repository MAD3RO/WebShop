using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShop.Models.Data
{
    [Table("tblCarts")]
    public class CartModel
    {
        [Key]
        public int CartId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel Users { get; set; }
    }
}