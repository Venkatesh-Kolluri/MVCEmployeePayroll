using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommanLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayrollMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminBL adminBL;
        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("admin/register")]
        public IActionResult RegisterAdmin()
        {
           
            return View();
        }
        [HttpPost]
        [Route("admin/register")]
        public IActionResult RegisterAdmin(AdminModel adminModel)
        {
            try
            {
                adminBL.RegisterAdmin(adminModel);
                return View(adminModel);
                // return RedirectToAction("AddEmployee");

            }
            catch (System.Exception)
            {

                throw;
            }

        }
        [HttpGet]
        [Route("admin/login")]
        public IActionResult LoginAdmin()
        {
            
            return View();
        }
        [HttpPost]
        [Route("admin/login")]
        public IActionResult LoginAdmin(AdminModel adminModel)
        {
            try
            {
              
                var result = adminBL.AdminLogin(adminModel);
                HttpContext.Session.SetInt32("EmpId", result.EmpId);
                if (result != null)
                {
                   
                    return RedirectToAction("GetAllEmployees", "Employee");
                }
                else
                {
                    ModelState.AddModelError("","Invalid empId or Name or password");
                }
                return View(adminModel);



            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}
