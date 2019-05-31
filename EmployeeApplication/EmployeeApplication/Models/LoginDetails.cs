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

        public string UserName { set { _userName = value; } }
        public string UserPassword { set { _userPassword = value; } }
    }
}