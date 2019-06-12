using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.Models
{
    public class AuditDetails
    {
        public int AuditId { get; set; }
        public string AuditMessage { get; set; }
    }
}