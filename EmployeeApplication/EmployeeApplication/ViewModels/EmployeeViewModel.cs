using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmpID { get; set; }
        public string EmpCompleteName { get; set; }
        public int Age { get; set; }
        public string MaritalStatus { get; set; }

        public List<EmployeeViewModel> GetEmpViewModel(List<EmployeeDetails> empList)
        {
            List<EmployeeViewModel> empVMList = new List<EmployeeViewModel>();
            EmployeeViewModel empVM;

            foreach (EmployeeDetails emp in empList)
            {
                empVM = new EmployeeViewModel();
                empVM.EmpID = emp.EmpId;
                empVM.EmpCompleteName = emp.FirstName + " " + emp.LastName;
                empVM.Age = emp.Age;
                empVM.MaritalStatus = emp.MaritalStatus == true ? "Married" : "Unmarried";
                empVMList.Add(empVM);
            }

            return empVMList;
        }
    }
}