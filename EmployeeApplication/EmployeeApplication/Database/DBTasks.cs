using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeApplication.Database
{
    public class DBTasks
    {
        private string connectionString;
        
        public DBTasks()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
        }

        public List<EmployeeDetails> GetEmployeeDetails()
        {
            List<EmployeeDetails> empList = new List<EmployeeDetails>();
            EmployeeDetails emp;
            SqlConnection connection = new SqlConnection(connectionString);
            string spName = "spGetEmployeeDetails";
            using (SqlCommand command = new SqlCommand(spName))
            {
                command.Connection = connection;
                connection.Open();
                DbDataReader reader = command.ExecuteReader();
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        foreach(DataRow row in reader)
                        {
                            emp = new EmployeeDetails();
                            emp.EmpId = int.Parse(row["ID"].ToString());
                            emp.FirstName = row["FirstName"].ToString();
                            emp.LastName = row["FirstName"].ToString();
                            emp.Age = int.Parse(row["FirstName"].ToString());
                            emp.Salary = double.Parse(row["Salary"].ToString());
                            emp.MaritalStatus = bool.Parse(row["FirstName"].ToString());
                            empList.Add(emp);
                        }                        
                    }
                }
                connection.Close();
            }

            //EmployeeDetails emp1 = new EmployeeDetails() {
            //    FirstName = "John",
            //    LastName = "Terry",
            //    Age = 28,
            //    Salary = 100,
            //    MaritalStatus = true };

            //empList.Add(emp1);

            //EmployeeDetails emp2 = new EmployeeDetails()
            //{
            //    FirstName = "Chris",
            //    LastName = "Evans",
            //    Age = 32,
            //    Salary = 500,
            //    MaritalStatus = true
            //};

            //empList.Add(emp2);

            return empList;
        }
    }
}