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
            SqlDataAdapter adapter;
            DataSet data = new DataSet();

            string spName = "spGetEmployeeDetails";
            using (SqlCommand command = new SqlCommand(spName))
            {
                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                if (data != null)
                {
                    foreach (DataRow row in data.Tables[0].Rows)
                    {
                        emp = new EmployeeDetails();
                        emp.EmpId = int.Parse(row["ID"].ToString());
                        emp.FirstName = row["FirstName"].ToString();
                        emp.LastName = row["LastName"].ToString();
                        emp.Age = int.Parse(row["Age"].ToString());
                        emp.MaritalStatus = bool.Parse(row["MaritalStatus"].ToString());
                        empList.Add(emp);
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