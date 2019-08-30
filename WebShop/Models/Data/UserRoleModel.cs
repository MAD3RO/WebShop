using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebShop.Models.Data
{
    [Table("tblUserRoles")]
    public class UserRoleModel
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        [Key, Column(Order = 1)]
        public int RoleId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }
        [ForeignKey("RoleId")]
        public virtual RoleModel Role { get; set; }
    }
}