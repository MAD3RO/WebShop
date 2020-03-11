using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebShop.Models.Data;

namespace WebShop.Models.ViewModels.Account
{
    public class UserProfileVM
    {
        public UserProfileVM()
        {

        }
        public UserProfileVM(UserModel row)
        {
            Id = row.Id;
            FirstName = row.FirstName;
            LastName = row.LastName;
            Username = row.Username;
            EmailAddress = row.EmailAddress;
            StreetAddress = row.StreetAddress;
            City = row.City;
            ZipCode = row.ZipCode;
            Contact = row.Contact;
            Password = row.PasswordHash;
            // Salt NEEDED !!!
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public long? ZipCode { get; set; }

        public long? Contact { get; set; }

        //[Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must contain minimum 6 characters.")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "You must confirm your password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}