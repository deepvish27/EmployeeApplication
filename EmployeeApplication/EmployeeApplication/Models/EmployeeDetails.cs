using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.Models
{
    public class EmployeeDetails
    {
        private int _empID;
        private string _firstName;
        private string _lastName;
        private int _age;
        private double _salary;
        private bool _maritalStatus;
        private string _locationName;
        private string _skillName;
        public int EmpId { get { return _empID; } set { _empID = value; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public double Salary { get { return _salary; } set { _salary = value; } }
        public bool MaritalStatus { get { return _maritalStatus; } set { _maritalStatus = value; } }
        public string LocationName { get { return _locationName; } set { _locationName = value; } }
        public string SkillName { get { return _skillName; } set { _skillName = value; } }
    }
}