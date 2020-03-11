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
        //[Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        //[Required]
        //[DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public long ZipCode { get; set; }
        public long Contact { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        //[DataType(DataType.DateTime)]
        public DateTime? DateCreated { get; set; }
    }
}