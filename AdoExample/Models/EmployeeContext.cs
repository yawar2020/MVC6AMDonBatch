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

        public List<Employee> GetEmployee()
        {
            List<Employee> listemp = new List<Employee>();
            SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Ganesh;Integrated Security=true");
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
    }
}