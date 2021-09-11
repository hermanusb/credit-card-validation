using CreditCardValidation.DAL;
using CreditCardValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreditCardValidation.Controllers
{
    public class LoginController : Controller
    {
        private CreditCardContext db = new CreditCardContext();

        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login(User user)
        {
            user = db.Users.Find(user.ID);
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Login Failure");
        }
    }
}