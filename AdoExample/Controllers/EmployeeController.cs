using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdoExample.Models;
namespace AdoExample.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            return View(db.GetEmployee().ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            Employee obj = new Employee();
            obj.EmpName =frm["EmpName"];
            obj.EmpSalary =Convert.ToInt32(frm["EmpSalary"]);
            int i = db.SaveEmployee(obj);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
           
        }
    }
}