using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.Models
{
    public class LoginDetails
    {
        private string _userName;
        private string _userPassword;

        public string UserName { get { return _userName; } set { _userName = value; } }
        public string UserPassword { get { return _userPassword; } set { _userPassword = value; } }
    }
}