using EmployeeApplication.Database;
using EmployeeApplication.Models;
using EmployeeApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<EmployeeDetails> empList = new List<EmployeeDetails>();
            List<EmployeeViewModel> empVMList = new List<EmployeeViewModel>();
            EmployeeViewModel empViewModel = new EmployeeViewModel();
            DBTasks db = new DBTasks();
            empList = db.GetEmployeeDetails();
            empVMList = empViewModel.GetEmpViewModel(empList);
            return View(empVMList);
        }

        [HttpGet]
        public ActionResult EditEmployeeInfo()
        {
            return View("EditEmployee");
        }
        
        [HttpGet]
        public string Statistics()
        {
            return "Statistics will be displayed here!!";
        }
    }
}