using CommanLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IAdminBL
    {
        public AdminModel RegisterAdmin(AdminModel adminModel);
        public AdminModel AdminLogin(AdminModel adminModel);
    }
}
