using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.ViewModels
{
    public class SkillAndLocationVM
    {
        public List<Skills> skillNames { get; set; }
        public List<Locations> locationNames { get; set; }
    }
}