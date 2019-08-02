using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            Id = row.Id;
            Body = row.Body;
        }
        public int Id { get; set; }
        public string Body { get; set; }
    }
}