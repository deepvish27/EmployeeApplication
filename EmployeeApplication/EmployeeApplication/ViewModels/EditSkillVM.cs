using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.ViewModels
{
    public class EditSkillVM
    {
        public string SkillName { get; set; }

        public List<Skills> AllSkillNames { get; set; }
    }
}