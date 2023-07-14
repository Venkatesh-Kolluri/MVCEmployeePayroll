using CommanLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBL
    {
        public EmployeeModel AddEmployee(EmployeeModel employee);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetAllEmployeesbyId(int id);
        public EmployeeModel UpdateEmployee(EmployeeModel employee);
        public EmployeeModel Delete(int id);
        // public EmployeeModel Delete(EmployeeModel employeeModel);
        public EmployeeModel LoginEmployee(EmpLoginModel empLoginModel);

    }
}
