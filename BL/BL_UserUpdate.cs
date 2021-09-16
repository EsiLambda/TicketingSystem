using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Models;
using DA.Repositories;

namespace BL
{
    public class BL_UserUpdate : DA_UserUpdate
    {
        public string email, password;

        public bool BL_UpdateUser()
        {
            if(password != "")
            {
                DA_UpdateUser(email, password);

                return true;
            }
            else
                return false;
        }

        public List<UserInformation> BL_ShowUpdatedUsers()
        {
            return DA_ShowUpdatedUsers();
        }
    }
}
