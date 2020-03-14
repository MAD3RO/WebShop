using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebShop.Models.ViewModels.Pages;

namespace WebShop.Models.Data
{
    //public class WebShopInitializer : System.Data.Entity.DropCreateDatabaseAlways<Db>

    public class WebShopInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Db>
    {
        protected override void Seed(Db context)
        {

        }
    }
}