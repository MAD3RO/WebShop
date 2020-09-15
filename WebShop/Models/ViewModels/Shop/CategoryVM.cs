using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models.Data;

namespace WebShop.Models.ViewModels.Shop
{
    public class CategoryVM
    {
        public CategoryVM()
        {

        }

        public CategoryVM(CategoryModel row)
        {
            Id = row.Id;
            Name = row.Name;
            Sorting = row.Sorting;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get { return Name.Replace(" ", "-").ToLower().Replace(".", "").Replace("/", ""); } }

        public int Sorting { get; set; }
    }
}