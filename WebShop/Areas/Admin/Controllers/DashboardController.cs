using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Enums;
using WebShop.Models.Data;
using WebShop.Models.ViewModels.Shop;

namespace WebShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            using (Db db = new Db())
            {
                // Get number of registered users
                int usersNum = db.Users.Where(x => x.IsGuest == false && x.Id != 1).ToList().Count;
                ViewBag.Users = usersNum;

                // Get number of orders
                int ordersNum = db.Orders.ToList().Count;
                ViewBag.Orders = ordersNum;

                // Get number of sold products and sum of monthly earnings
                var startOfTthisMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                var firstDay = startOfTthisMonth.AddMonths(-1);
                var lastDay = startOfTthisMonth.AddDays(-1);

                List<OrderVM> completedOrders = db.Orders.Where(x => x.Status == OrderStatus.Completed && x.CreatedAt >= firstDay && x.CreatedAt <= lastDay).ToArray().Select(x => new OrderVM(x)).ToList();

                // Declare monthly earnings counter
                decimal monthlyEarningsSum = 0;

                // Declare sold products counter
                int soldProductsNum = 0;

                if (completedOrders != null && completedOrders.Any())
                {
                    foreach (var completedOrder in completedOrders)
                    {
                        // Init list of OrderDetailsDTO
                        List<OrderDetailsModel> completedOrderDetailsList = db.OrderDetails.Where(X => X.OrderId == completedOrder.OrderId).ToList();

                        foreach (var orderDetails in completedOrderDetailsList)
                        {
                            // Get product
                            ProductModel product = db.Products.Where(x => x.Id == orderDetails.ProductId).FirstOrDefault();

                            // Get sum of monthly earnings
                            monthlyEarningsSum += orderDetails.Quantity * product.NewPrice;

                            // Get number of sold products
                            soldProductsNum += orderDetails.Quantity;
                        }
                    }
                }

                ViewBag.Earnings = monthlyEarningsSum;
                ViewBag.Products = soldProductsNum;
            }

            return View();
        }
    }
}