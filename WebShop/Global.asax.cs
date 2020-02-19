using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebShop.Models.Data;

namespace WebShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest()
        {
            // Check if user is logged in
            if (User == null) { return; }

            // Get username
            string username = Context.User.Identity.Name;

            // Declare array of roles
            string[] roles = null;

            using (Db db = new Db())
            {
                // Populate roles
                UserModel dto = db.Users.FirstOrDefault(x => x.Username == username);

                if (dto != null)
                {
                    roles = db.UserRoles.Where(x => x.UserId == dto.Id).Select(x => x.Role.Name).ToArray();
                }
                else
                {
                    return;
                }
            }

            // Build IPrincipal object
            IIdentity userIdentity = new GenericIdentity(username);
            IPrincipal newUserObj = new GenericPrincipal(userIdentity, roles);

            // Update Context.User
            Context.User = newUserObj;
        }
    }
}
