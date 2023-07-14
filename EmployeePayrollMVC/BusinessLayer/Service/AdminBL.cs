using BusinessLayer.Interface;
using CommanLayer.Models;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminRL adminRL;
        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }

        public AdminModel AdminLogin(AdminModel adminModel)
        {
            try
            {
                return adminRL.AdminLogin(adminModel);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public AdminModel RegisterAdmin(AdminModel adminModel)
        {
            try
            {
                return adminRL.RegisterAdmin(adminModel);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
