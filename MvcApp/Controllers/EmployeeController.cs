﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Models;
using BusinessLayer;



namespace MvcApp.Controllers
{
    public class EmployeeController : Controller
    {


        public ActionResult Index(int departmentId)
        {
            //EmployeeContext employeeContext = new EmployeeContext();
            //List<Employee> employees = employeeContext.Employees.Where(emp => emp.DepartmentId == departmentId ).ToList();


            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<BusinessLayer.Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }


        public ActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.EmployeeId == id);

            return View(employee);
        }
    }
}