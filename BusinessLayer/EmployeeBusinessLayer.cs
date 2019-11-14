using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {

        public IEnumerable<Employee> Employees
        {
            get
            {
                string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                List<Employee> employees = new List<Employee>();

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.City = rdr["City"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.DepartmentId = Convert.ToInt32(rdr["DepartmentId"]);

                        employees.Add(employee);
                    }

                }

                return employees;
            }
            
        }
    }
}
        

    


