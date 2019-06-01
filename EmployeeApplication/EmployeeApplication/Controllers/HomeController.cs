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

        [HttpPost]
        public ActionResult EditEmployeeInfo()
        {            
            return View("EditEmployee");
        }
        
        public ActionResult AddEmployeeView()
        {
            SkillAndLocationVM skillsAndLocationNames = new SkillAndLocationVM();
            skillsAndLocationNames.skillNames = GetSkillNames();
            skillsAndLocationNames.locationNames = GetLocationNames();
            return View("AddEmployee", skillsAndLocationNames);
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeDetails emp)
        {
            DBTasks db = new DBTasks();
            try
            {
                if (db.AddEmployee(emp))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }                
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        
        [HttpGet]
        public string Statistics()
        {
            return "Statistics will be displayed here!!";
        }
        
        private List<Skills> GetSkillNames()
        {
            DBTasks db = new DBTasks();
            List<Skills> skills = db.GetSkillNames();

            return skills;
        }
        
        private List<Locations> GetLocationNames()
        {
            DBTasks db = new DBTasks();
            List<Locations> locations = db.GetLocationNames();

            return locations;
        }
    }
}