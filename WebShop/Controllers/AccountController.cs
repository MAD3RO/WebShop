﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebShop.Models.Data;
using WebShop.Models.ViewModels;
using WebShop.Models.ViewModels.Account;
using WebShop.Models.ViewModels.Shop;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Shop");
        }

        //// GET: /Account/login
        [HttpGet]
        public ActionResult LoginPartial()
        {
            var model = new LoginUserVM();

            if (Request.Cookies.Get("username") != null && Request.Cookies.Get("password") != null)
            {
                model.Username = Request.Cookies["username"].Value;
                model.Password = Request.Cookies["password"].Value;
            }
            else
            {
                model.Username = "";
                model.Password = "";
            }
            model.RememberMe = !string.IsNullOrEmpty(model.Username);

            // Return view
            return PartialView(model);
        }

        //POST: /account/login-partial
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public JsonResult LoginPartial(LoginUserVM model)
        {
            // Check model state
            if (!ModelState.IsValid)
            {
                //return PartialView(model);
                return Json("error", JsonRequestBehavior.AllowGet);
            }

            // Check if the user is valid
            bool isValid = false;

            using (Db db = new Db())
            {
                var user = db.Users.SingleOrDefault(a => a.Username == model.Username);

                if (user != null)
                {
                    if (user.PasswordHash == CreatePasswordHash(model.Password, user.Salt))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                else
                {
                    isValid = false;
                }
            }

            if (!isValid)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return Json("error", JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (model.RememberMe)
                {
                    var ckUsername = new HttpCookie("username");
                    var ckPassword = new HttpCookie("password");
                    ckUsername.Expires = DateTime.Now.AddHours(24);
                    ckPassword.Expires = DateTime.Now.AddHours(24);
                    ckUsername.Value = model.Username;
                    ckPassword.Value = model.Password;
                    Response.Cookies.Add(ckUsername);
                    Response.Cookies.Add(ckPassword);
                }
                else
                {
                    // Remove cookie
                    var ckUsername = Request.Cookies["username"];
                    if (ckUsername != null)
                    {
                        Response.Cookies.Remove("username");
                        ckUsername.Expires = DateTime.Now.AddYears(-1);
                        ckUsername.Value = null;
                        Response.SetCookie(ckUsername);
                    }
                }
                FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                ModelState.Clear();
                return Json("success", JsonRequestBehavior.AllowGet);
            }
        }

        // GET: /Account/create-account
        [ActionName("create-account")]
        [HttpGet]
        public ActionResult CreateAccount()
        {
            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                return RedirectToAction("Index", "Shop");
            }
            else
            {
                return View("CreateAccount");
            }
        }

        // POST: /account/create-account
        [ActionName("create-account")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateAccount(UserVM model)
        {
            // Check model state
            if (!ModelState.IsValid)
            {
                return View("CreateAccount", model);
            }

            using (Db db = new Db())
            {
                // Make sure username is unique
                if (db.Users.Any(x => x.Username.Equals(model.Username)))
                {
                    ModelState.AddModelError("", "Username " + model.Username + " is taken.");
                    model.Username = "";
                    ViewBag.LoginPartial = "remove";
                    return View("CreateAccount", model);
                }

                // Make sure email is unique
                if (db.Users.Any(x => x.EmailAddress.Equals(model.EmailAddress)))
                {
                    ModelState.AddModelError("", "Email address " + model.EmailAddress + " already exists.");
                    model.EmailAddress = "";
                    ViewBag.LoginPartial = "remove";
                    return View("CreateAccount", model);
                }

                // Create salt
                var salt = CreateSalt();

                // Create userDTO
                UserModel userDTO = new UserModel()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    EmailAddress = model.EmailAddress,
                    Address = model.Address,
                    City = model.City,
                    ZipCode = model.ZipCode,
                    Contact = model.Contact,
                    PasswordHash = CreatePasswordHash(model.Password, salt),
                    Salt = salt,
                    DateCreated = DateTime.Now,
                    IsGuest = false
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
                    RoleId = 2 // 1 is for admin, 2 is for user, 3 is for guest
                };

                db.UserRoles.Add(userRolesDTO);
                db.SaveChanges();
            }

            // Create a TempData message
            TempData["SM"] = "Registration is successfully done.";

            return Redirect("~/account/create-account");
        }

        // GET: /account/Logout
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var url = Request.UrlReferrer.ToString().ToLower();

            if (url.Contains("checkout"))
            {
                return RedirectToAction("Index", "Cart");
            }
            else if (url.Contains("user-profile") || url.Contains("orders"))
            {
                return RedirectToAction("Index", "Shop");
            }
            else
            {
                return Redirect(url);
            }
        }

        [Authorize]
        public ActionResult UserNavPartial()
        {
            // Get username
            string username = User.Identity.Name;

            // Declare model
            UserNavPartialVM model;

            using (Db db = new Db())
            {
                // Get the user
                UserModel dto = db.Users.FirstOrDefault(x => x.Username == username);

                // Build the model
                model = new UserNavPartialVM()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    UserName = dto.Username
                };
            }

            // Return partial view with model
            return PartialView(model);
        }

        // GET: /account/user-profile
        [HttpGet]
        [ActionName("user-profile")]
        [Authorize]
        public ActionResult UserProfile()
        {
            // Get username
            string username = User.Identity.Name;

            // Declare model
            UserProfileVM model;

            using (Db db = new Db())
            {
                // Get user
                UserModel dto = db.Users.FirstOrDefault(x => x.Username == username);

                // Build model
                model = new UserProfileVM(dto);
            }

            // Return view with model
            return View("UserProfile", model);
        }

        // POST: /account/user-profile
        [HttpPost]
        [ActionName("user-profile")]
        [Authorize]
        public ActionResult UserProfile(UserProfileVM model)
        {
            var salt = CreateSalt();

            // Check model state
            if (!ModelState.IsValid)
            {
                return View("UserProfile", model);
            }

            //// Check if passwords match if need be
            //if (!string.IsNullOrWhiteSpace(model.Password))
            //{
            //    if (!model.Password.Equals(model.ConfirmPassword))
            //    {
            //        ModelState.AddModelError("", "Passwords do not match.");
            //        return View("UserProfile", model);
            //    }
            //}

            using (Db db = new Db())
            {
                // Get username
                string username = User.Identity.Name;

                // Make sure username is unique
                if (db.Users.Where(x => x.Id != model.Id).Any(x => x.Username == username))
                {
                    ModelState.AddModelError("", "Username " + model.Username + " already exists.");
                    model.Username = "";
                    return View("UserProfile", model);
                }

                // Edit DTO
                UserModel dto = db.Users.Find(model.Id);

                dto.FirstName = model.FirstName;
                dto.LastName = model.LastName;
                dto.Username = model.Username;
                dto.EmailAddress = model.EmailAddress;
                dto.Address = model.Address;
                dto.City = model.City;
                dto.ZipCode = model.ZipCode;
                dto.Contact = model.Contact;

                if (!string.IsNullOrWhiteSpace(model.Password))
                {
                    dto.PasswordHash = CreatePasswordHash(model.Password, salt);
                    dto.Salt = salt;
                }

                // Save
                db.SaveChanges();
            }

            // Set TempData message
            TempData["SM"] = "You have edited your profile!";

            // Redirect
            return Redirect("~/account/user-profile");
        }

        // GET: /account/Orders
        [Authorize(Roles = "User")]
        public ActionResult Orders()
        {
            // Init list of OrdersForUserVM
            var ordersForUser = new List<OrdersForUserVM>();

            using (Db db = new Db())
            {
                // Get user id
                UserModel user = db.Users.Where(x => x.Username == User.Identity.Name).FirstOrDefault();
                int userId = user.Id;

                // Init list of OrderVM
                List<OrderVM> orders = db.Orders.Where(x => x.UserId == userId).ToArray().Select(x => new OrderVM(x)).ToList();

                // Loop through list of OrderVM
                foreach (var order in orders)
                {
                    // Init products dict
                    Dictionary<string, int> productsAndQty = new Dictionary<string, int>();

                    // Declare total
                    decimal total = 0m;

                    // Init list of OrderDetailsDTO
                    List<OrderDetailsModel> orderDetailsDTO = db.OrderDetails.Where(x => x.OrderId == order.OrderId).ToList();

                    // Loop though list of OrderDetailsDTO
                    foreach (var orderDetails in orderDetailsDTO)
                    {
                        // Get product
                        ProductModel product = db.Products.Where(x => x.Id == orderDetails.ProductId).FirstOrDefault();

                        // Get product price
                        decimal price = product.NewPrice;

                        // Get product name
                        string productName = product.Name;

                        // Add to products dict
                        productsAndQty.Add(productName, orderDetails.Quantity);

                        // Get total
                        total += orderDetails.Quantity * price;
                    }

                    // Add to OrdersForUserVM list
                    ordersForUser.Add(new OrdersForUserVM()
                    {
                        OrderNumber = order.OrderId,
                        Total = total,
                        ProductsAndQty = productsAndQty,
                        CreatedAt = order.CreatedAt,
                        Status = order.Status,
                        PaymentMethod = order.PaymentMethod
                    });
                }
            }

            // Return view with list of OrdersForUserVM
            return View(ordersForUser);
        }

        #region Helper methods
        /// <summary>
        /// Create the password hash method
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public string CreatePasswordHash(string pwd, string salt)
        {
            string pwdAndSalt = String.Concat(pwd, salt);
            string hashedPwd = GetSwcSHA1(pwdAndSalt);

            return hashedPwd;
        }

        /// <summary>
        /// Generating the salt method
        /// </summary>
        /// <returns></returns>
        public string CreateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var saltSize = 32;
            byte[] buff = new byte[saltSize];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetSwcSHA1(string value)
        {
            SHA1 algorithm = SHA1.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(value));
            string sh1 = "";
            for (int i = 0; i < data.Length; i++)
            {
                sh1 += data[i].ToString("x2").ToUpperInvariant();
            }
            return sh1;
        }
        #endregion
    }
}