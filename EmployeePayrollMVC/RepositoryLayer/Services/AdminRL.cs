using CommanLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{
    public class AdminRL : IAdminRL
    {

        private readonly IConfiguration iconfig;
        readonly SqlConnection connection = new SqlConnection();
        readonly string connectionString;
        public AdminRL(IConfiguration iconfig)
        {
            this.iconfig = iconfig;
            connectionString = iconfig.GetConnectionString("EmployeePayrollDB");
            connection.ConnectionString = connectionString;

        }

        public AdminModel RegisterAdmin(AdminModel adminModel)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spRegisterAdmin", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@EmpId", adminModel.EmpId);
                cmd.Parameters.AddWithValue("@Name", adminModel.Name);
                cmd.Parameters.AddWithValue("@Password", adminModel.Password);

                cmd.ExecuteNonQuery();
                connection.Close();
                return adminModel;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public AdminModel AdminLogin(AdminModel adminModel)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spAdminLogin", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
              //  cmd.Parameters.AddWithValue("@AdminId", adminModel.AdminId);
                cmd.Parameters.AddWithValue("@Name", adminModel.Name);
                cmd.Parameters.AddWithValue("@Password", adminModel.Password);
                // AdminModel adminModel = new AdminModel();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    adminModel.AdminId = Convert.ToInt32(reader["AdminId"]);
                    adminModel.Name = reader["Name"].ToString();
                    adminModel.Password = reader["Password"].ToString();
                   /* if (adminModel.AdminId != null)
                    {
                        Session["Name"] = adminModel.Name.ToString();

                    }*/
                }
                //cmd.ExecuteNonQuery();
                connection.Close();
                return adminModel;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
