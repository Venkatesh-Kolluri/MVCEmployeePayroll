using CommanLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public EmployeeModel AddEmployee(EmployeeModel employee);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetAllEmployeesbyId(int id);
        public EmployeeModel UpdateEmployee(EmployeeModel employee);
      //  public EmployeeModel Delete(EmployeeModel employeeModel);
        public EmployeeModel Delete(int id);
        public EmployeeModel LoginEmployee(EmpLoginModel empLoginModel);
    }
}
