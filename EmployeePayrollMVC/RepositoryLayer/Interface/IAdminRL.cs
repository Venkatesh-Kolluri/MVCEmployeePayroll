using CommanLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAdminRL
    {
        public AdminModel RegisterAdmin(AdminModel adminModel);
        public AdminModel AdminLogin(AdminModel adminModel);

    }
}
