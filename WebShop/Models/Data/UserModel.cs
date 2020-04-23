using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShop.Models.Data
{
    [Table("tblUsers")]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public long? ZipCode { get; set; }

        public long? Contact { get; set; }

        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool IsGuest { get; set; }

        // Maybe in future?
        //public bool IsVerified { get; set; }
        //public Guid ActivationCode { get; set; }
    }
}