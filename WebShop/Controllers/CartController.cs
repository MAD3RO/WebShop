﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebShop.Models.Data;
using WebShop.Models.ViewModels.Account;
using WebShop.Models.ViewModels.Cart;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            // Init the cart list
            var cart = Session["cart"] as List<CartVM> ?? new List<CartVM>();

            // Check if cart is empty
            if (cart.Count == 0 || Session["cart"] == null)
            {
                ViewBag.Message = "Your cart is empty.";
                return View();
            }

            // Calculate total and save to ViewBag

            decimal total = 0m;

            foreach (var item in cart)
            {
                total += item.Total;
            }

            ViewBag.GrandTotal = total;

            // Return view with list
            return View(cart);
        }

        public ActionResult CartPartial()
        {
            // Init CartVM
            CartVM model = new CartVM();

            // Init quantity
            int qty = 0;

            // Init  price
            decimal price = 0m;

            // Init total price
            decimal total = 0m;

            // Check for cart session
            if (Session["cart"] != null)
            {
                // Get total qty and price
                var list = (List<CartVM>)Session["cart"];

                foreach (var item in list)
                {
                    qty += item.Quantity;
                    total += item.Total;
                }

                model.Quantity = qty;
                ViewBag.GrandTotal = total;
                ViewBag.CartVMList = list;
            }
            else
            {
                // Or set qty and price to 0
                model.Quantity = 0;
                model.Price = 0m;
            }

            // Return partial view with model
            return PartialView(model);
        }

        public ActionResult AddToCartPartial(int id)
        {
            // Init CartVM list
            List<CartVM> cart = Session["cart"] as List<CartVM> ?? new List<CartVM>();

            // Init CartVM
            CartVM model = new CartVM();

            using (Db db = new Db())
            {
                // Get the product
                ProductModel product = db.Products.Find(id);

                // Check if the product is already in cart
                var productInCart = cart.FirstOrDefault(x => x.ProductId == id);

                // If not, add new
                if (productInCart == null)
                {
                    cart.Add(new CartVM()
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        Quantity = 1,
                        Price = product.NewPrice,
                        Image = product.ImageName,
                        Slug = product.Slug,
                        Description = product.Description
                    });
                }
                else
                {
                    // If it is, increment
                    productInCart.Quantity++;
                }
            }

            // Get total qty and price and add to model
            int qty = 0;
            decimal total = 0m;

            foreach (var item in cart)
            {
                qty += item.Quantity;
                total += item.Total;
            }

            model.Quantity = qty;

            // Save cart back to session
            Session["cart"] = cart;
            ViewBag.CartVMList = cart;

            return PartialView("CartPartial", model);
        }

        // GET: /Cart/IncrementProduct
        public JsonResult IncrementProduct(int productId)
        {
            // Init cart list
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            using (Db db = new Db())
            {
                // Get cartVM from list
                CartVM model = cart.FirstOrDefault(x => x.ProductId == productId);

                // Increment qty
                model.Quantity++;

                // Store needed data
                var result = new { qty = model.Quantity, price = model.Price };

                // Return json with data
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: /Cart/DecrementProduct
        //public ActionResult DecrementProduct(int productId)
        public JsonResult DecrementProduct(int productId)
        {
            // Init cart
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            using (Db db = new Db())
            {
                // Get model from list
                CartVM model = cart.FirstOrDefault(x => x.ProductId == productId);

                // Decrement qty
                if (model.Quantity > 1)
                {
                    model.Quantity--;
                }
                else
                {
                    model.Quantity = 0;
                    cart.Remove(model);
                }

                // Store needed data
                var result = new { qty = model.Quantity, price = model.Price };

                // Return json
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        // GET: /Cart/RemoveProduct
        public void RemoveProduct(int productId)
        {
            // Init cart list
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            using (Db db = new Db())
            {
                // Get model from list
                CartVM model = cart.FirstOrDefault(x => x.ProductId == productId);

                // Remove model from list
                cart.Remove(model);
            }
        }

        public ActionResult PaypalPartial()
        {
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            return PartialView(cart);
        }

        // POST: /Cart/PlaceOrder
        [HttpPost]
        public void PlaceOrder()
        {
            // Get cart list
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            // Get username
            string username = User.Identity.Name;
            int orderId = 0;

            using (Db db = new Db())
            {
                // Init OrderDTO
                OrderModel orderDTO = new OrderModel();

                // Get user id
                var q = db.Users.FirstOrDefault(x => x.Username == username);
                int userId = q.Id;

                // Add to OrderDTO and save
                orderDTO.UserId = userId;
                orderDTO.CreatedAt = DateTime.Now;

                db.Orders.Add(orderDTO);
                db.SaveChanges();

                // Get inserted id
                orderId = orderDTO.OrderId;

                // Init OrderDetailsDTO
                OrderDetailsModel orderDetailsDTO = new OrderDetailsModel();

                // Add to OrderDetailsDTO
                foreach (var item in cart)
                {
                    orderDetailsDTO.OrderId = orderId;
                    orderDetailsDTO.UserId = userId;
                    orderDetailsDTO.ProductId = item.ProductId;
                    orderDetailsDTO.Quantity = item.Quantity;

                    db.OrderDetails.Add(orderDetailsDTO);
                    db.SaveChanges();
                }
            }

            // Email admin
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("6f6e00fa066652", "efd12fae5a9eed"),
                EnableSsl = true
            };
            client.Send("admin@example.com", "admin@example.com", "New Order", "You have a new order. Order number " + orderId);

            // Reset session
            Session["cart"] = null;
        }

        //[ActionName("checkout-as-guest")]
        //public ActionResult CheckoutAsGuest()
        //{
        //    List<CartVM> cart = Session["cart"] as List<CartVM>;
        //    int qty = 0;
        //    decimal total = 0m;

        //    foreach (var item in cart)
        //    {
        //        total += item.Total;
        //    }

        //    ViewBag.GrandTotal = total;
        //    ViewBag.CartVMList = cart;

        //    return View("Checkout");
        //}

        //public ActionResult Checkout()
        //{
        //    return View("Checkout");
        //}

        public ActionResult Checkout()
        {
            List<CartVM> cart = Session["cart"] as List<CartVM>;
            decimal total = 0m;

            foreach (var item in cart)
            {
                total += item.Total;
            }

            ViewBag.GrandTotal = total;
            ViewBag.CartVMList = cart;

            // Get username
            string username = User.Identity.Name;

            if (string.IsNullOrEmpty(username))
            {
                return View();
            }
            else
            {
                UserProfileVM model;

                using (Db db = new Db())
                {
                    // Get user
                    UserModel dto = db.Users.FirstOrDefault(x => x.Username == username);

                    // Build model
                    model = new UserProfileVM(dto);
                }
                return View(model);
            }
        }

        public ActionResult CheckoutPartial()
        {
            return PartialView();
        }
    }
}