using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models.Data;

namespace WebShop.Models.ViewModels.Pages
{
    public class SidebarVM
    {
        public SidebarVM()
        {

        }

        public SidebarVM(SidebarModel row)
        {
            Body = row.Body;
            Id = row.Id;
        }
        public int Id { get; set; }
        [AllowHtml]
        public string Body { get; set; }
    }
}