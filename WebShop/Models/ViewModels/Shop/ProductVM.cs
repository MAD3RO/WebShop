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

        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        public string Slug { get { return Name.Replace(" ", "-").ToLower().Replace(".", "").Replace("/", ""); } }

        [Required(ErrorMessage = "Product description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product price is required.")]
        [Range(1, 3000, ErrorMessage = "Please enter a value between {1} and {2}")]
        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal NewPrice { get; set; }

        public DateTime DateAdded { get; set; }

        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        //[Required(ErrorMessage = "Product image is required.")]
        public string Image { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public IEnumerable<string> GalleryImages { get; set; }
    }
}