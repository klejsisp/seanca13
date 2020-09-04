using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using seanca13.Identity;
using seanca13.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace seanca13.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account




        //LOGIMI
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel lg)
        {
            if (ModelState.IsValid)
            {
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var user = userManager.Find(lg.username, lg.password);
                if (user != null)
                {

                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);

                    if (userManager.IsInRole(user.Id, "Admin"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (userManager.IsInRole(user.Id, "Financa"))
                    {
                        return Content("Faqja e Finances");
                    }
                    else
                    {
                        return Content("Faqja e klientit");
                    }
                }

                else
                { ViewBag.Mesazh = "Usernami ose pasuordi i pasakte!"; return View(); }

            }
            else { return View(); }
        }



        //REGJISTRIMI

        public ActionResult Regjistrim()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Regjistrim(RegisterViewModel rg)
        {
            if (ModelState.IsValid)
            {
               var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rg.password);
                var user = new ApplicationUser() { Email = rg.email, UserName = rg.username, PasswordHash = passwordHash,emri=rg.name };
                IdentityResult result = userManager.Create(user);

                if (result.Succeeded)
                {

                    userManager.AddToRole(user.Id, "Customer");
                   var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                    
                }
                   return RedirectToAction("Index", "Home"); 
            }
            else
            {
                  return View();
            }
        }
    }
}