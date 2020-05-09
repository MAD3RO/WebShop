using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebShop.Models.Data;

namespace WebShop.Models.ViewModels.Account
{
    public class UserVM
    {
        public UserVM()
        {
        }

        public UserVM(UserModel row)
        {
            FirstName = row.FirstName;
            LastName = row.LastName;
            Username = row.Username;
            EmailAddress = row.EmailAddress;
            Address = row.Address;
            City = row.City;
            ZipCode = row.ZipCode;
            Contact = row.Contact;
            Password = row.PasswordHash;
        }

        [Required(ErrorMessage = "Firstname is required.")]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Zip code is required.")]
        [DisplayName("Zip code")]
        public long? ZipCode { get; set; }

        [Required(ErrorMessage = "Contact number is required.")]
        public long? Contact { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must contain minimum 6 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must confirm your password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match.")]
        [DisplayName("Cinfirm password")]
        public string ConfirmPassword { get; set; }
    }
}