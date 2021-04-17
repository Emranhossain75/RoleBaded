using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RusaMiaChairmanBari.Models;
using System.Web.Security;

namespace RusaMiaChairmanBari.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
       
        RusaMiaBariDBEntities db = new RusaMiaBariDBEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin_table ad)
        {
            var obj = db.Admin_table.Where(a => a.Admin.Equals(ad.Admin) && a.Password.Equals(ad.Password)).FirstOrDefault();
            if (obj != null)
            {
                FormsAuthentication.SetAuthCookie(ad.Admin,false);
                return RedirectToAction("Index", "FiftyTakaData");
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName && Password");
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
    }
}