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
        Dictionary<string, IEnumerable<ProductVM>> _viewType;

        // GET: Shop
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Pages");
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

        // GET: /shop/CategoryMenuPartial
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
            _viewType = Grid(orderBy, gridToggle, name, "", page, pageSize, priceRangeFrom, priceRangeTo);
            if (_viewType.FirstOrDefault().Value == null)
            {
                return View(_viewType.FirstOrDefault().Key);
            }
            else
            {
                return View(_viewType.FirstOrDefault().Key, _viewType.FirstOrDefault().Value);
            }
        }

        // GET: /shop/search/searchString
        //[HttpGet]
        public ActionResult Search(string orderBy, string gridToggle, string searchString, int page = 1, int pageSize = 12, decimal priceRangeFrom = 0.00m, decimal priceRangeTo = 3000.00m)
        {
            _viewType = Grid(orderBy, gridToggle, "", searchString, page, pageSize, priceRangeFrom, priceRangeTo);
            if (_viewType.FirstOrDefault().Value == null)
            {
                return View(_viewType.FirstOrDefault().Key);
            }
            else
            {
                return View(_viewType.FirstOrDefault().Key, _viewType.FirstOrDefault().Value);
            }
        }

        // GET: /shop/SpecialDeals
        //[HttpGet]
        public ActionResult SpecialDeals(string orderBy, string gridToggle, int page = 1, int pageSize = 12, decimal priceRangeFrom = 0.00m, decimal priceRangeTo = 3000.00m)
        {
            _viewType = Grid(orderBy, gridToggle, "", "", page, pageSize, priceRangeFrom, priceRangeTo);
            if (_viewType.FirstOrDefault().Value == null)
            {
                return View(_viewType.FirstOrDefault().Key);
            }
            else
            {
                return View(_viewType.FirstOrDefault().Key, _viewType.FirstOrDefault().Value);
            }
        }

        #region Helper methods
        public Dictionary<string, IEnumerable<ProductVM>> Grid(string orderBy, string gridToggle, string name, string searchString, int page = 1, int pageSize = 12, decimal priceRangeFrom = 0.00m, decimal priceRangeTo = 3000.00m)
        {
            // Declare a list of ProductVM
            IEnumerable<ProductVM> productVMList = null;

            // Declare view name
            string viewName = "";

            // Declare view type
            var viewType = new Dictionary<string, IEnumerable<ProductVM>>();

            // Set price range from
            ViewBag.PriceRangeFrom = priceRangeFrom;

            // Set price range to
            ViewBag.PriceRangeTo = priceRangeTo;

            using (Db db = new Db())
            {
                // Init the list
                if (searchString == "" && name == "") // Special Deals
                {
                    // Set page type
                    viewName = "SpecialDeals";

                    productVMList = db.Products.ToArray().Where(x => x.Discount > 0).Select(x => new ProductVM(x));
                    if (productVMList == null || productVMList.ToList().Count == 0)
                    {
                        ViewBag.Message = "There are no products with discount.";
                        viewType.Add(viewName, null);
                        return viewType;
                    }
                }
                else if (name != "") // Category
                {
                    // Set page type
                    viewName = "Category";

                    // Get category id
                    CategoryModel categoryDTO = db.Categories.Where(x => x.Slug == name).FirstOrDefault();
                    int catId = categoryDTO.Id;

                    // Get category name
                    ProductModel productCat = db.Products.Where(x => x.CategoryId == catId).FirstOrDefault();

                    // Save category name
                    ViewBag.CategoryName = categoryDTO.Name;

                    // Init the list
                    productVMList = db.Products.ToArray().Where(x => x.CategoryId == catId).Select(x => new ProductVM(x));

                    if (productVMList == null || productVMList.ToList().Count == 0)
                    {
                        ViewBag.Message = "There are no products in " + categoryDTO.Name + " category.";
                        viewType.Add(viewName, null);
                        return viewType;
                    }
                }
                else if (searchString != "")
                {
                    // Set page type
                    viewName = "Search";

                    // Save search result
                    ViewBag.SearchString = searchString;

                    // Init the list
                    productVMList = db.Products.ToArray().Where(x => x.Name.ToLower().Contains(searchString.ToLower())).Select(x => new ProductVM(x));

                    if (productVMList == null || productVMList.ToList().Count == 0)
                    {
                        ViewBag.Message = "Your search for '" + searchString + "' did not match any products.";
                        viewType.Add(viewName, null);
                        return viewType;
                    }
                }

                // Filter product list with price range
                productVMList = productVMList.Where(x => x.NewPrice >= priceRangeFrom && x.NewPrice <= priceRangeTo);

                if (productVMList == null || productVMList.ToList().Count == 0)
                {
                    ViewBag.PriceRangeNotFound = "We have found 0 products that match that price range.";
                    viewType.Add(viewName, null);
                    return viewType;
                }

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

            // Return view with list
            viewType.Add(viewName, productVMList.ToList());
            return viewType;
        }
        #endregion
    }
}