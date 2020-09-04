using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using seanca13.Identity;

[assembly: OwinStartup(typeof(seanca13.Startup))]

namespace seanca13
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {


            app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login") });
            this.CreateRolesAndUsers();
        }
        public void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var appDbContext = new ApplicationDbContext();
            var appUserStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(appUserStore);


            //Admini
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

         
            if (userManager.FindByName("klejsi") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "klejsi";
                user.Email = "klejsi@gmail.com";
                string userPassword = "klejsi";
                var chkUser = userManager.Create(user, userPassword);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            //Financa          
            if (!roleManager.RoleExists("Financa"))
            {
                var role = new IdentityRole();
                role.Name = "Financa";
                roleManager.Create(role);
            }


            if (userManager.FindByName("klejsi1") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "klejsi1";
                user.Email = "klejsi1@gmail.com";
                string userPassword = "klejsi";
                var chkUser = userManager.Create(user, userPassword);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Financa");
                }
            }

            //Klienti
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }

        }
    }
}
