using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebShop.Models.Data;

namespace WebShop.Models.ViewModels.Shop
{
    public class CheckoutVM
    {
        public CheckoutVM()
        {
        }
        public CheckoutVM(UserModel row)
        {
            FirstName = row.FirstName;
            LastName = row.LastName;
            EmailAddress = row.EmailAddress;
            Address = row.Address;
            City = row.City;
            ZipCode = row.ZipCode;
            Contact = row.Contact;
        }

        [Required(ErrorMessage = "Firstname is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Zip code is required.")]
        public long? ZipCode { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        public long? Contact { get; set; }

        public string PaymentMethod { get; set; }

        public bool IsChecked { get; set; }
    }
}