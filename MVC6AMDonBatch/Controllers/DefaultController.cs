using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC6AMDonBatch.Models;
namespace MVC6AMDonBatch.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
       
        public ViewResult Index()
        {
            return View("~/Views/Home/MyHome.cshtml");
        }
        [Route("Toys/Car")]
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult BirthdayWishes() {
            string Wishes = "Happy Birthday to You";
            ViewBag.info = Wishes;
            return View("~/Views/Home/MyHome.cshtml");
        }
        public ActionResult Employeeinfo()
        {
            List<EmployeeModel> dbobj = new List<EmployeeModel>();

            EmployeeModel obj = new EmployeeModel();
            obj.Empid = 1;
            obj.EmpName = "Naveen";
            obj.EmpSalary = 25000;

            EmployeeModel obj1 = new EmployeeModel();
            obj1.Empid = 2;
            obj1.EmpName = "Bhavna";
            obj1.EmpSalary = 35000;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.Empid = 3;
            obj2.EmpName = "Don";
            obj2.EmpSalary = 45000;
            //ViewBag.Empinfo = obj;

            dbobj.Add(obj);
            dbobj.Add(obj1);
            dbobj.Add(obj2);

            return View(dbobj);
        }

        public ActionResult GetEmployeeDetails()
        {

            DepartmentModel deptobj = new Models.DepartmentModel();
            deptobj.Deptid = 1;
            deptobj.DeptName = "IT";


            List<EmployeeModel> dbobj = new List<EmployeeModel>();

            EmployeeModel obj = new EmployeeModel();
            obj.Empid = 1;
            obj.EmpName = "Naveen";
            obj.EmpSalary = 25000;

            EmployeeModel obj1 = new EmployeeModel();
            obj1.Empid = 2;
            obj1.EmpName = "Bhavna";
            obj1.EmpSalary = 35000;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.Empid = 3;
            obj2.EmpName = "Don";
            obj2.EmpSalary = 45000;
    

            dbobj.Add(obj);
            dbobj.Add(obj1);
            dbobj.Add(obj2);

            EmpDeptModel listobj = new EmpDeptModel();
            listobj.DepartmentModels = deptobj;
            listobj.EmployeeModels = dbobj;



            return View(listobj);
        }

        public PartialViewResult GetPartialData()
        {
            List<EmployeeModel> dbobj = new List<EmployeeModel>();

            EmployeeModel obj = new EmployeeModel();
            obj.Empid = 1;
            obj.EmpName = "Naveen";
            obj.EmpSalary = 25000;

            EmployeeModel obj1 = new EmployeeModel();
            obj1.Empid = 2;
            obj1.EmpName = "Bhavna";
            obj1.EmpSalary = 35000;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.Empid = 3;
            obj2.EmpName = "Don";
            obj2.EmpSalary = 45000;


            dbobj.Add(obj);
            dbobj.Add(obj1);
            dbobj.Add(obj2);

            return PartialView("_EmployeePartialView",dbobj);
        }
        public RedirectResult GO()
        {
            // return Redirect("~/Default/BirthdayWishes");
            return Redirect("http://www.google.com");

        }
        public RedirectToRouteResult GOToRoute()
        {
            // return Redirect("~/Default/BirthdayWishes");
            //return Redirect("http://www.google.com");

            return RedirectToRoute("Default2");
        }

        public RedirectToRouteResult GotOActionMethod()
        {

            return RedirectToAction("MyHome", "Home");
        }

        public JsonResult GetJsonData()
        {
            List<EmployeeModel> dbobj = new List<EmployeeModel>();

            EmployeeModel obj = new EmployeeModel();
            obj.Empid = 1;
            obj.EmpName = "Naveen";
            obj.EmpSalary = 25000;

            EmployeeModel obj1 = new EmployeeModel();
            obj1.Empid = 2;
            obj1.EmpName = "Bhavna";
            obj1.EmpSalary = 35000;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.Empid = 3;
            obj2.EmpName = "Don";
            obj2.EmpSalary = 45000;


            dbobj.Add(obj);
            dbobj.Add(obj1);
            dbobj.Add(obj2);

            return Json(dbobj,JsonRequestBehavior.AllowGet);
        }
        public  FileResult GetFile()
        {
            return File("~/Web.config", "application/xml","Web.config");
        }
        public ContentResult GetContent(int? id) {

            if (id == 1) {
                return Content("<p style='color:red'>Hello World</p>");
            }
            else if (id ==2)
            {
                return Content("<script>alert('Hello World')</script>");
            }
            else
            {
                return Content("Hello World");
            }
        }
    }
}