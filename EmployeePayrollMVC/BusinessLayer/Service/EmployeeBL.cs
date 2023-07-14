using BusinessLayer.Interface;
using CommanLayer.Models;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRL employeeRL;

        public EmployeeBL(IEmployeeRL employeeRL)
		{
			this.employeeRL = employeeRL;
		}

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
			try
			{
				return employeeRL.AddEmployee(employee);

			}
			catch (Exception)
			{

				throw;
			}
        }
        public IEnumerable<EmployeeModel> GetAllEmployees()
		{
			try
			{
				return employeeRL.GetAllEmployees();
			}
			catch (Exception)
			{

				throw;
			}
		}
        public EmployeeModel GetAllEmployeesbyId(int id)
        {
            try
            {
                return employeeRL.GetAllEmployeesbyId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public EmployeeModel UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                return employeeRL.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public EmployeeModel Delete(int id)
        {
            try
            {
                return employeeRL.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EmployeeModel LoginEmployee(EmpLoginModel empLoginModel)
        {
            try
            {
                return employeeRL.LoginEmployee(empLoginModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
