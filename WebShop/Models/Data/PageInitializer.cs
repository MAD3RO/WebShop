using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop.Models.ViewModels.Pages;

namespace WebShop.Models.Data
{
    public class PageInitializer : System.Data.Entity.DropCreateDatabaseAlways<Db>
    {
        protected override void Seed(Db context)
        {
            var Pages = new List<PageModel>
            {
                new PageModel{Title="Home", HasSidebar=false, Body="home page", Slug="home", Sorting=0},
            };

            //var Pages = new List<PageVM>
            //{
            //    new PageVM{Title="Home", HasSidebar=false, Body="home page", Slug="home", Sorting=0}
            //};

            Pages.ForEach(s => context.Pages.Add(s));
            context.SaveChanges();
        }
    }
}