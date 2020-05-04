using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models.Data;

namespace WebShop.Models.ViewModels.Shop
{
    public class ProductVM
    {
        public ProductVM()
        {
        }

        public ProductVM(ProductModel row)
        {
            Id = row.Id;
            Name = row.Name;
            Slug = row.Slug;
            Description = row.Description;
            Price = row.Price;
            Discount = row.Discount;
            NewPrice = row.NewPrice;
            DateAdded = row.DateAdded;
            CategoryName = row.CategoryName;
            CategoryId = row.CategoryId;
            Image = row.Image;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Slug { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal NewPrice { get; set; }

        public DateTime DateAdded { get; set; }

        public string CategoryName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Image { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public IEnumerable<string> GalleryImages { get; set; }
    }
}