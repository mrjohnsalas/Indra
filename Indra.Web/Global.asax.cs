using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Indra.Model.Models;

namespace Indra.Web
{
    public class MvcApplication : HttpApplication
    {
        private string AdminUserId => ConfigurationManager.AppSettings["AdminUserId"];

        private string DefaultPassword => ConfigurationManager.AppSettings["DefaultPassword"];

        protected void Application_Start()
        {
            var db = new ApplicationDbContext();
            CreateRoles(db);
            CreateSuperUser(db);
            AddPermisionsToSuperUser(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void CreateRoles(DbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));
        }

        private void CreateSuperUser(DbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName(AdminUserId);
            if (user != null) return;
            user = new ApplicationUser
            {
                FirstName = "John",
                LastName = "Salas",
                PhoneNumber = "987575442",
                UserName = AdminUserId,
                Email = AdminUserId
            };
            userManager.Create(user, DefaultPassword);
        }

        private void AddPermisionsToSuperUser(DbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindByName(AdminUserId);
            if (!userManager.IsInRole(user.Id, "Admin"))
                userManager.AddToRole(user.Id, "Admin");
        }
    }
}
