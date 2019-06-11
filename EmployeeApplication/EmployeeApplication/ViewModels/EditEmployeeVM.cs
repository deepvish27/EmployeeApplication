using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.ViewModels
{
    public class EditEmployeeVM
    {
        public EmployeeDetails empDetails { get; set; }
        public List<Skills> SkillNames { get; set; }
        public List<Locations> LocationList { get; set; }
    }
}