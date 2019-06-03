using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.Models
{
    public class CustomError
    {
        public string CustomErrorMessage { get; set; }
        public CustomError(string errMsg)
        {
            CustomErrorMessage = errMsg;
        }
    }
}