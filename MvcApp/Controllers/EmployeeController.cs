using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;
using BusinessLayer;
using Employee = BusinessLayer.Employee;


namespace MvcApp.Controllers
{
    public class EmployeeController : Controller
    {


        public ActionResult Index1()
        {
            //EmployeeContext employeeContext = new EmployeeContext();
            //List<Employee> employees = employeeContext.Employees.Where(emp => emp.DepartmentId == departmentId ).ToList();


            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<BusinessLayer.Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }


        //public ActionResult Details(int id)
        //{
        //    EmployeeContext employeeContext = new EmployeeContext();
        //    Employee employee = employeeContext.Employees.Single(emp => emp.EmployeeId == id);

        //    return View(employee);
        //}

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();

                UpdateModel(employee);
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.AddEmployee(employee);

                return RedirectToAction("Index1");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.EmployeeId == id);

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.SaveEmployee(employee);
                return RedirectToAction("Index1");
                
            }
            return View(employee);
        }


    }
}