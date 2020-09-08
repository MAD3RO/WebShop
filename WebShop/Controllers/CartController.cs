﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebShop.Enums;
using WebShop.Models.Data;
using WebShop.Models.ViewModels.Cart;
using WebShop.Models.ViewModels.Shop;

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

        public ActionResult AddToCartPartial(int id, int qty = 1)
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
                        Quantity = qty,
                        Price = product.NewPrice,
                        Image = product.Image,
                        //Slug = product.Slug,
                        Description = product.Description
                    });
                }
                else
                {
                    // If it is, increment
                    productInCart.Quantity = productInCart.Quantity + qty;
                }
            }

            // Get total qty and price and add to model
            decimal total = 0m;
            qty--;
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

        // GET: /Cart/PaypalPartial
        public ActionResult PaypalPartial()
        {
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            if (cart == null)
                return PartialView();

            return PartialView(cart);
        }

        // GET: /Cart/PlaceOrder
        public ActionResult Checkout()
        {
            List<CartVM> cart = Session["cart"] as List<CartVM>;
            decimal total = 0m;

            if (cart == null)
            {
                // Create a TempData message
                TempData["Checkout"] = "Your order has been recieved and is now being processed.";
                return View();
            }

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
                ViewBag.IsAuthenticated = "false";
                return View();
            }
            else
            {
                CheckoutVM model;

                using (Db db = new Db())
                {
                    // Get user
                    UserModel dto = db.Users.FirstOrDefault(x => x.Username == username);

                    // Build model
                    model = new CheckoutVM(dto);
                }

                ViewBag.IsAuthenticated = "true";
                return View(model);
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Checkout(CheckoutVM model)
        {
            // Get username
            string username = User.Identity.Name;

            if (string.IsNullOrEmpty(username))
            {
                // Check model state
                if (!ModelState.IsValid)
                {
                    return View("Checkout", model);
                }

                using (Db db = new Db())
                {
                    // Create userDTO
                    UserModel userDTO = new UserModel()
                    {
                        Username = "Guest_" + Guid.NewGuid().ToString().Substring(0, 15),
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        EmailAddress = model.EmailAddress,
                        Address = model.Address,
                        City = model.City,
                        ZipCode = model.ZipCode,
                        Contact = model.Contact,
                        DateCreated = DateTime.Now,
                        IsGuest = true
                    };

                    // Add the DTO
                    db.Users.Add(userDTO);

                    // Save
                    db.SaveChanges();

                    // Add to UserRolesDTO
                    int id = userDTO.Id;

                    UserRoleModel userRolesDTO = new UserRoleModel()
                    {
                        UserId = id,
                        RoleId = 3 // 1 is for admin, 2 is for user, 3 is for guest
                    };

                    db.UserRoles.Add(userRolesDTO);
                    db.SaveChanges();
                }
            }

            // Get cart list
            List<CartVM> cart = Session["cart"] as List<CartVM>;

            int orderId = 0;

            using (Db db = new Db())
            {
                // Init OrderDTO
                OrderModel orderDTO = new OrderModel();

                // Get user id
                var q = db.Users.FirstOrDefault(x => x.EmailAddress == model.EmailAddress);
                int userId = q.Id;

                // Add to OrderDTO and save
                orderDTO.UserId = userId;
                orderDTO.CreatedAt = DateTime.Now;
                orderDTO.Status = model.PaymentMethod == "paypal" ? OrderStatus.Paid : OrderStatus.Pending;
                orderDTO.PaymentMethod = Enum.GetName(typeof(PaymentMethod), model.PaymentMethod == "paypal" ? PaymentMethod.Paypal : PaymentMethod.Cash);

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
                    //orderDetailsDTO.UserId = userId;
                    orderDetailsDTO.ProductId = item.ProductId;
                    orderDetailsDTO.Quantity = item.Quantity;

                    db.OrderDetails.Add(orderDetailsDTO);
                    db.SaveChanges();
                }
            }

            var authToken = "K7Z9vgWERat816CAw3VbLrkfYu8HJwYYRuwJQn-jTmnGgTdp7LI-p6CBRJq";

            //read in txn token from querystring
            var txToken = Request.QueryString.Get("tx");

            var query = string.Format("cmd=_notify-synch&tx={0}&at={1}", txToken, authToken);

            // Create the request back
            string url = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            // Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = query.Length;

            // Write the request back IPN strings
            StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            stOut.Write(query);
            stOut.Close();

            // Do the request to PayPal and get the response
            StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            var strResponse = stIn.ReadToEnd();
            stIn.Close();

            // If response was SUCCESS, parse response string and output details
            if (strResponse.StartsWith("SUCCESS"))
            {

            }

            System.Threading.Thread.Sleep(50);

            // Reset session
            Session["cart"] = null;

            ModelState.Clear();
            return Redirect("~/cart/Checkout");
        }

        public ActionResult haha()
        {
            return Redirect("/");
        }
    }
}