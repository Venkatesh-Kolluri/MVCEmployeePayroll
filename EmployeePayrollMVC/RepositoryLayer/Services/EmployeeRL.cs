using CommanLayer.Models;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly IConfiguration config;
        readonly string sqlConnectString;
       // private readonly IEnumerable<EmployeeModel> employee;
        readonly SqlConnection connection = new SqlConnection();

        public EmployeeRL(IConfiguration config)
        {
            this.config = config;
            sqlConnectString = config.GetConnectionString("EmployeePayrollDB");
            connection.ConnectionString = sqlConnectString;
        }
        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spAddEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Profile_Image", employee.Profile_Image);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);
              //  cmd.Parameters.AddWithValue("@IsTrash", employee.IsTrash);
              //  cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
               
                // cmd.Parameters.AddWithValue()

                cmd.ExecuteNonQuery();
                connection.Close();
                return employee;
              
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                List<EmployeeModel> listemployee = new List<EmployeeModel>();
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeModel employee = new EmployeeModel();
                   
                    employee.EmpId  = Convert.ToInt32(rdr["EmpId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Profile_Image = rdr["Profile_Image"].ToString();
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = rdr["Department"].ToString();
                    employee.StartDate = rdr.GetDateTime(6);
                    employee.Salary = Convert.ToInt64(rdr["Salary"]);     
                    employee.Notes = rdr["Notes"].ToString();
                    employee.IsTrash = Convert.ToBoolean(rdr["IsTrash"]);
                    // employee.CreatedAt = rdr.GetDateTime(6);
                    employee.UpdateDate= rdr.GetDateTime(6);
                    listemployee.Add(employee);
                }
              
                connection.Close();
                return listemployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmployeeModel GetAllEmployeesbyId(int id)
        {
            try
            {
               
                SqlCommand cmd = new SqlCommand("spGetAllEmployeesbyId", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                connection.Open();
                cmd.Parameters.AddWithValue("@EmpId", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                EmployeeModel employee = new EmployeeModel();

                while (rdr.Read())
                {
                   
                    employee.EmpId = Convert.ToInt32(rdr["EmpId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = Convert.ToString(rdr["Gender"]);
                    employee.Department = rdr["Department"].ToString();
                    employee.Profile_Image = rdr["Profile_Image"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.StartDate = rdr.GetDateTime(6);
                    employee.IsTrash = Convert.ToBoolean(rdr["IsTrash"]);
                    employee.Notes = rdr["Notes"].ToString();
                    // employee.CreatedAt = rdr.GetDateTime(9);
                    employee.UpdateDate = rdr.GetDateTime(10);
                }

                connection.Close();
                return employee;
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
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Profile_Image", employee.Profile_Image);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);
          //   cmd.Parameters.AddWithValue("@IsTrash", employee.IsTrash);
         //       cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
               
                cmd.ExecuteNonQuery();
                connection.Close();
                return employee;
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
                EmployeeModel employeeModel = new EmployeeModel();
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
               
                cmd.Parameters.AddWithValue("@EmpId", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return employeeModel;
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
                SqlCommand cmd = new SqlCommand("spLoginEmployee", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmpId", empLoginModel.EmpId);
                cmd.Parameters.AddWithValue("@Name", empLoginModel.Name);
                EmployeeModel employeeModel = new EmployeeModel();
              
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employeeModel.EmpId = Convert.ToInt32(reader["EmpId"]);
                    employeeModel.Name = reader["Name"].ToString();
                    employeeModel.Profile_Image = reader["Profile_Image"].ToString();
                    employeeModel.Gender = reader["Gender"].ToString();
                    employeeModel.Department = reader["Department"].ToString();
                    employeeModel.Salary = Convert.ToInt32(reader["Salary"]);
                    employeeModel.StartDate = reader.GetDateTime(6);
                    employeeModel.Notes = reader["Notes"].ToString();
                    employeeModel.UpdateDate = reader.GetDateTime(6);
                }
                //cmd.ExecuteNonQuery();
               
                connection.Close();
                reader.Close();
                return employeeModel;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }    
}
