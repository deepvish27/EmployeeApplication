using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.ViewModels
{
    public class EditEmployeeVM
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public bool MaritalStatus { get; set; }
        public string LocationName { get; set; }
        public string SkillName { get; set; }
    }
}