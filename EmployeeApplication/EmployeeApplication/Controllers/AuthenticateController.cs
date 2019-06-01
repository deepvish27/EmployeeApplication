using EmployeeApplication.Database;
using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApplication.Controllers
{
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
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Error");
            }
        }
    }
}