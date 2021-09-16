using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DA.Repositories;

namespace BL
{
    public class BL_UserAuthentication : DA_UserAuthentication
    {
        public string email, password;

        public bool UserLogIn()
        {
            return DA_AdminLogIn(email, password);
        }

        public int Role()
        {
            return DA_Role(email);
        }
    }
}
