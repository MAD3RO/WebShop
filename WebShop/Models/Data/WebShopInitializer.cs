using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models.ViewModels.Pages;

namespace WebShop.Models.Data
{
    public class WebShopInitializer : System.Data.Entity.DropCreateDatabaseAlways<Db>
    {
        protected override void Seed(Db context)
        {
            // Page initializer
            var Pages = new List<PageModel>
            {
                new PageModel{Title="Home", HasSidebar=false, Body="home page", Slug="home", Sorting=0},
            };

            Pages.ForEach(s => context.Pages.Add(s));
            context.SaveChanges();

            // Sidebar initializer
            var Sidebar = new List<SidebarModel>
            {
                new SidebarModel{Body="home page"}
            };

            Sidebar.ForEach(s => context.Sidebar.Add(s));
            context.SaveChanges();
        }
    }
}