using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Details()
        {

            Employee employee = new Employee()
            {
                City = "NewYork",
                EmployeeId = 12,
                Gender = "M",
                Name = "Papastopulos"
            };
            return View();
        }
    }
}