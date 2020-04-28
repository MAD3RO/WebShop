using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShop.Models.Data
{
    [Table("tblProducts")]
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public decimal Discount { get; set; }
        public decimal NewPrice { get { return Math.Round(Discount > 0 ? Price - (Discount / 100) * Price : Price, 2); } }

        [ForeignKey("CategoryId")]
        public virtual CategoryModel Category { get; set; }
    }
}