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
                    cmd.Parameters.Add("@LocationName", SqlDbType.NVarChar).Value = emp.LocationName;
                    cmd.Parameters.Add("@SkillName", SqlDbType.NVarChar).Value = emp.SkillName;
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

        public bool UpdateEmployeeDetails(EmployeeDetails emp)
        {
            bool status = false;

            SqlConnection conn = new SqlConnection(connectionString);
            string spName = "spUpdateEmployeeDetails";
            using(SqlCommand cmd=new SqlCommand(spName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = emp.EmpId;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = emp.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = emp.LastName;
                cmd.Parameters.Add("@Age", SqlDbType.Int).Value = emp.Age;
                cmd.Parameters.Add("@Salary", SqlDbType.Decimal).Value = emp.Salary;
                cmd.Parameters.Add("@MaritalStatus", SqlDbType.Int).Value = emp.MaritalStatus;
                cmd.Parameters.Add("@LocationName", SqlDbType.NVarChar).Value = emp.LocationName;
                cmd.Parameters.Add("@SkillName", SqlDbType.NVarChar).Value = emp.SkillName;
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    status = true;
                }
                conn.Close();
            }
            return status;
        }

        public List<Locations> GetLocationNames()
        {
            List<Locations> locations = new List<Locations>();
            Locations location;
            string spName = "spGetLocationNames";
            SqlConnection conn = new SqlConnection(connectionString);
            DataSet data = new DataSet();
            SqlDataAdapter adapter;
            using (SqlCommand cmd=new SqlCommand(spName))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                if (data != null)
                {
                    foreach(DataRow row in data.Tables[0].Rows)
                    {
                        location = new Locations();
                        location.Location = row["LocationName"].ToString();
                        locations.Add(location);
                    }
                }
            }

            return locations;
        }

        
        public List<Skills> GetSkillNames()
        {
            List<Skills> skills = new List<Skills>();

            Skills skill;
            string spName = "spGetSkillNames";
            SqlConnection conn = new SqlConnection(connectionString);
            DataSet data = new DataSet();
            SqlDataAdapter adapter;
            using (SqlCommand cmd = new SqlCommand(spName))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                if (data != null)
                {
                    foreach (DataRow row in data.Tables[0].Rows)
                    {
                        skill = new Skills();
                        skill.Skill = row["SkillName"].ToString();
                        skills.Add(skill);
                    }
                }
            }

            return skills;
        }

        public bool ValidUser(LoginDetails user)
        {
            bool status = false;

            SqlConnection conn = new SqlConnection(connectionString);
            string spName = "spValidateUser";
            DataSet data = new DataSet();
            SqlDataAdapter adapter;

            using (SqlCommand cmd=new SqlCommand(spName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = user.UserName;
                cmd.Parameters.Add("@UserPassword", SqlDbType.NVarChar).Value = user.UserPassword;
                conn.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                conn.Close();
                if (data != null && data.Tables[0].Rows.Count >0)
                {
                    if(Convert.ToInt32(data.Tables[0].Rows[0][0]) == 1)
                    {
                        status = true;
                    }
                }                
            }
            return status;
        }

        public bool RemoveEmployee(int id)
        {
            bool status = false;

            string spName = "spRemoveEmployee";
            SqlConnection conn = new SqlConnection(connectionString);

            using(SqlCommand cmd=new SqlCommand(spName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    status = true;
                }
                conn.Close();
            }
            return status;
        }

        public EmployeeDetails GetEmployeeById(int id)
        {
            EmployeeDetails emp = new EmployeeDetails();

            SqlConnection conn = new SqlConnection(connectionString);
            DataSet data = new DataSet();
            SqlDataAdapter adapter;
            string spName = "spGetEmployeeById";
            using(SqlCommand cmd=new SqlCommand(spName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(data);
                conn.Close();
                if (data != null && data.Tables[0].Rows.Count > 0)
                {
                    emp.EmpId = Convert.ToInt32(data.Tables[0].Rows[0]["ID"]);
                    emp.FirstName = data.Tables[0].Rows[0]["FirstName"].ToString();
                    emp.LastName = data.Tables[0].Rows[0]["LastName"].ToString();
                    emp.Age = Convert.ToInt32(data.Tables[0].Rows[0]["Age"]);
                    emp.Salary = Convert.ToDouble(data.Tables[0].Rows[0]["Salary"]);
                    emp.MaritalStatus = Convert.ToInt16(data.Tables[0].Rows[0]["MaritalStatus"]) == 1 ? true : false;
                    emp.LocationName = data.Tables[0].Rows[0]["LocationName"].ToString();
                    emp.SkillName = data.Tables[0].Rows[0]["SkillName"].ToString();
                }
            }

            return emp;
        }
    }
}