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

        [HttpGet]
        public ActionResult Edit(int ? id)
        {
            Employee emp = db.GetEmployeebyId(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            int i = db.EditEmployee(emp);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Employee emp = db.GetEmployeebyId(id);
            return View(emp);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            int i = db.DeleteEmployee(id);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public ActionResult GetViewDataExample()
        {
            List<string> obj = new List<string>();
            obj.Add("pratiusha");
            obj.Add("deepti");
            obj.Add("Nagini");
            obj.Add("Anusha");
            //  ViewData["Student"] = obj;
            ViewBag.student = obj;
            return View();
        }
        public ActionResult getTempData() {
            TempData["Name"] = "Hello World";
            return RedirectToAction("getTempData1");
        }
        public ActionResult getTempData1()
        {
            //string s=TempData["Name"].ToString();
            //TempData.Keep();
            string s = TempData.Peek("Name").ToString();
            ViewBag.info = s;
            return View();
        }
    }
}