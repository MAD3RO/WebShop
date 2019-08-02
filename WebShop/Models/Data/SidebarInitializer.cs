using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models.Data
{
    public class SidebarInitializer : System.Data.Entity.DropCreateDatabaseAlways<Db>
    {
        protected override void Seed(Db context)
        {
            var Sidebar = new List<SidebarModel>
            {
                new SidebarModel{Body="Sidebar body"}
            };

            Sidebar.ForEach(s => context.Sidebar.Add(s));
            context.SaveChanges();
        }
    }
}