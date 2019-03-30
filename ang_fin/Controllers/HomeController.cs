using ang_fin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ang_fin.Controllers
{
    public class HomeController : Controller
    {
        DbEntity db = new DbEntity();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult LoadData()
        {
            List<Employee> employees = db.Employees.ToList();
            return Json(employees, JsonRequestBehavior.AllowGet);
        }

        public string SaveData(Employee employee)
        {
            if (employee != null)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return "Data Saved";
            }
            else
            {
                return "Data Not Saved";
            }
        }

        public string DeleteData(Employee employee)
        {
            if (employee != null)
            {
                var emp = db.Entry(employee);
                if (emp.State == System.Data.Entity.EntityState.Detached)
                {
                    db.Employees.Attach(employee);
                    db.Employees.Remove(employee);
                }

                db.SaveChanges();
                return "Data Deleted";
            }
            else
            {
                return "Data Not Deleted";
            }
        }

        //public string UpdateData(Employee employee)
        //{
        //    if (employee != null)
        //    {
        //        db.Entry(employee);
        //        Employee emp = db.Employees.Where(a => a.Id == employee.Id)
        //            .FirstOrDefault();
        //        emp.Id = employee.Id;
        //        emp.Name = employee.Name;
        //        emp.Email = employee.Email;

        //        db.SaveChanges();
        //        return "Data Updated";
        //    }
        //    else
        //    {
        //        return "Data Not Updated";
        //    }
        //}

        public string UpdateData(Employee employee)
        {
            if (employee != null)
            {
                db.Entry(employee);
                Employee emp = db.Employees.Where(w => w.Id == employee.Id).FirstOrDefault();
                emp.Id = employee.Id;
                emp.Name = employee.Name;
                emp.Email = employee.Email;

                db.SaveChanges();
                return "Data Updated";
            }
            else
            {
                return "Data Not Updated";
            }
        }
    }
}