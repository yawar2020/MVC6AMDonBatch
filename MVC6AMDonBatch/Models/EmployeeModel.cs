using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC6AMDonBatch.Models
{
    public class EmployeeModel
    {
        public int Empid { get; set; }
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }
    }

    public class DepartmentModel
    {
        public int Deptid { get; set; }
        public string DeptName { get; set; }
    }

    public class EmpDeptModel
    {
        public List<EmployeeModel> EmployeeModels { get; set; }
        public DepartmentModel DepartmentModels { get; set; }
    }

}