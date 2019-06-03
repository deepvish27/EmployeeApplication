using EmployeeApplication.Database;
using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmployeeApplication.Controllers
{
    [AllowAnonymous]
    public class AuthenticateController : Controller
    {
        // GET: Authenticate
        public ActionResult LoginView()
        {
            return View("LoginView");
        }
        [HttpPost]
        public ActionResult ValidateUser(LoginDetails user)
        {
            DBTasks db = new DBTasks();
            if (db.ValidUser(user))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("ValidateUserNamePassword", @"Username/Password is Invalid!");
                return View("LoginView");
            }
        }
    }
}