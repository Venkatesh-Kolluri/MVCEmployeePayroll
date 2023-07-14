using BusinessLayer.Interface;
using CommanLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBL employeeBL;
        public EmployeeController(IEmployeeBL employeeBL)
        {
           
            this.employeeBL = employeeBL;
        }
        public IActionResult Index()
        {
           // HttpContext.Session.SetString(nameof,@Name) = "Welcome to browser";
            //  Session["Var2"] = "Open in Browser";
            return View();
        }

        // Add employees

        [HttpGet]
        [Route("employee/add")]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        [Route("employee/add")]
        public IActionResult AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeBL.AddEmployee(employeeModel);
                    
                     return RedirectToAction("AddEmployee");
                }
                return View(employeeModel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Get all employee

        [HttpGet]
        [Route("admin/dashboard")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                /*  ViewData["Var1"] = "open web Page";
                  TempData["Var2"] = "open browser";*/
                List<EmployeeModel> employees = new List<EmployeeModel>();
                employees = employeeBL.GetAllEmployees().ToList();
                if(employees== null)
                {
                    return NotFound();
                }
                else
                {
                    return View(employees);
                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]
        [Route("employee/dashboard")]
        public IActionResult GetAllEmployeesbyId(int id)
        {
            try
            {
                //   EmployeeModel employee = new EmployeeModel();
               
              id= (int)HttpContext.Session.GetInt32("EmpId");
                if (id == null)
                {
                    return NotFound();
                }
               
                var employee = employeeBL.GetAllEmployees().FirstOrDefault(m => m.EmpId == id);
                TempData["EmpName"] = employee.Name;


                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("employee/update")]
        public IActionResult UpdateEmployee(int id)
        {
            var employee = employeeBL.GetAllEmployees().FirstOrDefault(m => m.EmpId == id);
         //   TempData["EmpName"] = employee.Name;
            return View(employee);
        }
        [HttpPost]
        [Route("employee/update")]
        public IActionResult UpdateEmployee(EmployeeModel model)
        {
            try
            {
                model.EmpId = (int)HttpContext.Session.GetInt32("EmpId");
                employeeBL.UpdateEmployee(model);
                return View(model);

            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("employee/delete")]
        public IActionResult Delete(int id)
        {

            var employee = employeeBL.GetAllEmployees().FirstOrDefault(m => m.EmpId == id);
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            try
            {

                employeeBL.Delete(id);
                return RedirectToAction("GetAllEmployees");
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("employee/login")]
       
        public IActionResult LoginEmployee()
        {
            return View();
        }

        [HttpPost]
        [Route("employee/login")]
        
        public IActionResult LoginEmployee(EmpLoginModel empLoginModel)
        {
            try
            {
                var result = employeeBL.LoginEmployee(empLoginModel);
                HttpContext.Session.SetInt32("EmpId", result.EmpId);
                if (result != null)
                {
                    
                    return RedirectToAction("GetAllEmployeesbyId" );
                }
                else
                {
                    ModelState.AddModelError("", "Invalid EmployeeId or Name");
                }
                return View(empLoginModel);



            }
            catch (System.Exception)
            {

                throw;
            }

        }

    }

}
