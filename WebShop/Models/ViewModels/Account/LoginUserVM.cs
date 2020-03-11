﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Models.ViewModels.Account
{
    public class LoginUserVM
    {
        [Required(ErrorMessage = "Username is required.")]
        //[MaxLength(150, ErrorMessageResourceType = typeof(ErrorResource), ErrorMessageResourceName = "CheckLenght")]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}