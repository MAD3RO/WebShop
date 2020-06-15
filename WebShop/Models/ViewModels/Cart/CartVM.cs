using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models.ViewModels.Cart
{
    public class CartVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get { return Quantity * Price; } }

        public string Image { get; set; }

        public string Slug { get { return ProductName.Replace(" ", "-").ToLower(); } }

        public string Description { get; set; }
    }
}