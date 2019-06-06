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
        
        public ActionResult EditEmployeeById(int id)
        {
            DBTasks db = new DBTasks();
            EmployeeDetails emp = db.GetEmployeeById(id);

            EditEmployeeVM editEmp = new EditEmployeeVM();
            editEmp.empDetails = emp;
            editEmp.skillList = GetSkillNames();
            editEmp.LocationList = GetLocationNames();

            return View("EditEmployee", editEmp);
        }
        [HttpPost]
        public ActionResult SearchEmployee(string searchBy, string SearchValue)
        {
            SearchValue = Server.HtmlEncode(SearchValue);
            List<EmployeeViewModel> empResult = new List<EmployeeViewModel>();
            if (!string.IsNullOrEmpty(searchBy))
            {
                if (!string.IsNullOrEmpty(SearchValue))
                {
                    DBTasks db = new DBTasks();
                    empResult = db.SearchEmployee(searchBy, SearchValue);
                    return View("Index", empResult);
                }
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult AddEmployeeView()
        {
            SkillAndLocationVM skillsAndLocationNames = new SkillAndLocationVM();
            skillsAndLocationNames.skillNames = GetSkillNames();
            skillsAndLocationNames.locationNames = GetLocationNames();
            return View("AddEmployee", skillsAndLocationNames);
        }
        
        public ActionResult RemoveEmployee(int id)
        {
            DBTasks db = new DBTasks();
            try
            {
                if (db.RemoveEmployee(id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    CustomError errMsg = new CustomError("An error occurred!");
                    return RedirectToAction("Error", errMsg);
                }
            }
            catch (Exception ex)
            {
                CustomError errMsg = new CustomError("An error occurred: " + ex.Message);
                return View("Error", errMsg);
            }
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
                    CustomError errMsg = new CustomError("An error occurred!");
                    return View("Error", errMsg);
                }                
            }
            catch (Exception ex)
            {
                CustomError errMsg = new CustomError("An error occurred: " + ex.Message);
                return View("Error", errMsg);
            }
        }
        [HttpPost]
        public ActionResult UpdateEmployeeDetails(EmployeeDetails emp)
        {
            DBTasks db = new DBTasks();
            try
            {
                if (db.UpdateEmployeeDetails(emp))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    CustomError errMsg = new CustomError("An error occurred!");
                    return View("Error", errMsg);
                }
            }
            catch(Exception ex)
            {
                CustomError errMsg = new CustomError("An error occurred: " + ex.Message);
                return View("Error", errMsg);
            }
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