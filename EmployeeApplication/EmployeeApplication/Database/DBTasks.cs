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
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();

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
            }
            
            return empList;
        }

        public bool AddEmployee(EmployeeDetails emp)
        {
            bool status = false;

            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                string spName = "spInsertValuesIntoEmployeeTbl";

                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = emp.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = emp.LastName;
                    cmd.Parameters.Add("@Age", SqlDbType.Int).Value = emp.Age;
                    cmd.Parameters.Add("@Salary", SqlDbType.Decimal).Value = emp.Salary;
                    cmd.Parameters.Add("@MaritalStatus", SqlDbType.Bit).Value = emp.MaritalStatus;
                    conn.Open();
                    int affectedRows = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (affectedRows > 0)
                    {
                        status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
            }
    }
}