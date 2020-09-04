using seanca13.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace seanca13.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Menaxho()
        {
            var db = new ApplicationDbContext();
            var user = db.Users.ToList();
            return View(user);
            
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ApplicationUser a)
        {
            if (ModelState.IsValid)
            {
                var db = new ApplicationDbContext();
                var pas = Crypto.HashPassword(a.PasswordHash);
                a.PasswordHash = pas;
                db.Users.Add(a);
                db.SaveChanges();
                return RedirectToAction("Menaxho");
            } return View();
        }


        public ActionResult Delete(string id) {

            var db = new ApplicationDbContext();
            
            var kl=db.Users.Where(tmp=>tmp.Id==id).FirstOrDefault();
            db.Users.Remove(kl);
            db.SaveChanges();

            return RedirectToAction("Menaxho","Home");
        }

      
    }
}