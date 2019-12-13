using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace AdoExample.Models
{
    public class EmployeeContext
    {
        SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Ganesh;Integrated Security=true");

        public List<Employee> GetEmployee()
        {
            List<Employee> listemp = new List<Employee>();
            SqlCommand cmd = new SqlCommand("sp_GetEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Employee emp = new Employee();
                emp.EmpId = Convert.ToInt32(dr[0]);
                emp.EmpName = dr[1].ToString();
                emp.EmpSalary = Convert.ToInt32(dr[2]);
                listemp.Add(emp);
            }
            return listemp;
        }

        public int SaveEmployee(Employee obj)
        {
            SqlCommand cmd = new SqlCommand("sp_SaveEmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@EmpName",obj.EmpName);
            cmd.Parameters.AddWithValue("@EmpSalary",obj.EmpSalary);
            object i = (Object)cmd.ExecuteScalar();
            int result = Convert.ToInt32(i);
            con.Close();
            return result;
        }
    }
}