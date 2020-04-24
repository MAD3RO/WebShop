using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models.Data;
using WebShop.Models.ViewModels.Shop;

namespace WebShop.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Pages");
        }

        public ActionResult CategoryMenuPartial()
        {
            // Declare list of CategoryVM
            List<CategoryVM> categoryVMList;

            // Init the list
            using (Db db = new Db())
            {
                categoryVMList = db.Categories.ToArray().OrderBy(x => x.Sorting).Select(x => new CategoryVM(x)).ToList();
            }

            // Return partial with list
            return PartialView(categoryVMList);
        }

        // GET: /shop/category/name
        public ActionResult Category(string name, string orderBy, string gridToggle, int page = 1, int pageSize = 12, decimal priceRangeFrom = 0.00m, decimal priceRangeTo = 3000.00m)
        {
            // Declare a list of ProductVM
            IEnumerable<ProductVM> productVMList;

            // Set price range to

            using (Db db = new Db())
            {
                // Get category id
                CategoryModel categoryDTO = db.Categories.Where(x => x.Slug == name).FirstOrDefault();
                int catId = categoryDTO.Id;

                // Init the list
                productVMList = db.Products.ToArray().Where(x => x.CategoryId == catId).Select(x => new ProductVM(x));

                // Filter product list with price range
                productVMList = productVMList.Where(x => x.NewPrice >= priceRangeFrom && x.NewPrice <= priceRangeTo);

                // Sort order
                switch (orderBy)
                {
                    case "nameDesc":
                        productVMList = productVMList.OrderByDescending(s => s.Name);
                        break;
                    case "priceAsc":
                        productVMList = productVMList.OrderBy(s => s.NewPrice);
                        break;
                    case "priceDesc":
                        productVMList = productVMList.OrderByDescending(s => s.NewPrice);
                        break;
                    case "nameAsc":
                    default:
                        productVMList = productVMList.OrderBy(s => s.Name);
                        break;
                }

                // Get category name
                ProductModel productCat = db.Products.Where(x => x.CategoryId == catId).FirstOrDefault();

                ViewBag.CategoryName = categoryDTO.Name;

                if (productCat == null)
                {
                    ViewBag.Message = "There are no products in " + categoryDTO.Name + " category.";
                    return View();
                }

                // Set selected page size
                ViewBag.SelectedPageSize = pageSize;
                // Set selected order
                ViewBag.OrderBy = string.IsNullOrEmpty(orderBy) ? "name_asc" : orderBy;
            }

            // Set pagination
            var onePageOfProducts = productVMList.ToPagedList(page, pageSize);
            ViewBag.OnePageOfProducts = onePageOfProducts;

            // Set show toggle
            ViewBag.GridToggle = string.IsNullOrEmpty(gridToggle) ? "grid" : gridToggle;

            // Set price range from
            ViewBag.PriceRangeFrom = priceRangeFrom;

            // Set price range to
            ViewBag.PriceRangeTo = priceRangeTo;

            // Return view with list
            return View(productVMList.ToList());
        }

        // GET: /shop/product-details/name
        [ActionName("product-details")]
        public ActionResult ProductDetails(string name)
        {
            // Declare the VM and DTO
            ProductVM model;
            ProductModel dto;

            // Init product id
            int id = 0;

            using (Db db = new Db())
            {
                // Check if product exists
                if (!db.Products.Any(x => x.Slug.Equals(name)))
                {
                    return RedirectToAction("Index", "Shop");
                }

                // Init productDTO
                dto = db.Products.Where(x => x.Slug == name).FirstOrDefault();

                // Get id
                id = dto.Id;

                // Init model
                model = new ProductVM(dto);
            }

            // Get gallery images
            try
            {
                model.GalleryImages = Directory.EnumerateFiles(Server.MapPath("~/Images/Uploads/Products/" + id + "/Gallery/Thumbs"))
                                                        .Select(fn => Path.GetFileName(fn));
            }
            catch (Exception)
            {
                return View("ProductDetails", model);
            }

            // Return view with model
            return View("ProductDetails", model);
        }

        // GET: /shop/search/searchString
        //[HttpGet]
        public ActionResult Search(string orderBy, string gridToggle, string searchString, int page = 1, int pageSize = 12, decimal priceRangeFrom = 0.00m, decimal priceRangeTo = 3000.00m)
        {
            // Declare a list of ProductVM
            IEnumerable<ProductVM> productVMList;

            using (Db db = new Db())
            {
                // Init the list
                productVMList = db.Products.ToArray().Where(x => x.Name.ToLower().Contains(searchString.ToLower())).Select(x => new ProductVM(x));

                // Filter product list with price range
                productVMList = productVMList.Where(x => x.NewPrice >= priceRangeFrom && x.NewPrice <= priceRangeTo);

                // Sort order
                switch (orderBy)
                {
                    case "nameDesc":
                        productVMList = productVMList.OrderByDescending(s => s.Name);
                        break;
                    case "priceAsc":
                        productVMList = productVMList.OrderBy(s => s.NewPrice);
                        break;
                    case "priceDesc":
                        productVMList = productVMList.OrderByDescending(s => s.NewPrice);
                        break;
                    case "nameAsc":
                    default:
                        productVMList = productVMList.OrderBy(s => s.Name);
                        break;
                }

                if (productVMList == null || productVMList.ToList().Count == 0)
                {
                    ViewBag.Message = "Your search for '" + searchString + "' did not match any products.";
                    return View();
                }

                // Set selected page size
                ViewBag.SelectedPageSize = pageSize;
                // Set selected order
                ViewBag.OrderBy = string.IsNullOrEmpty(orderBy) ? "name_asc" : orderBy;
            }

            // Set pagination
            var onePageOfProducts = productVMList.ToPagedList(page, pageSize);
            ViewBag.OnePageOfProducts = onePageOfProducts;

            // Set show toggle
            ViewBag.GridToggle = string.IsNullOrEmpty(gridToggle) ? "grid" : gridToggle;

            // Save search result
            ViewBag.SearchString = searchString;

            // Set price range from
            ViewBag.PriceRangeFrom = priceRangeFrom;

            // Set price range to
            ViewBag.PriceRangeTo = priceRangeTo;

            // Return view with list
            return View(productVMList.ToList());
        }
    }
}