using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using DA.Models;
using DA.Repositories;

namespace BL
{
    public class BL_UserTicket : DA_UserTicket
    {
        public string email, topic, section, importance, description;

        public void BL_Insert()
        {
            DA_Insert(MakeInfoString());
        }

        public void BL_Update(Guid id)
        {
            DA_Update(id, MakeInfoString());
        }

        public void BL_Delete(Guid id)
        {
            DA_Delete(id);
        }

        public Guid BL_GetUserID()
        {
            return DA_GetUserID(email);
        }

        public object BL_ShowUserTicket(string emailAuth)
        {
            return DA_ShowUserTicket(emailAuth);
        }

        public object BL_ShowAllTickets()
        {
            return DA_ShowAllTickets();
        }

        public List<UserInformation> BL_SelectDeafaultInfo(string email)
        {
            return DA_SelectDeafaultInfo(email);
        }

        private string[] MakeInfoString()
        {
            string[] strInfo = new[] { email, topic, section, importance, description };

            return strInfo;
        }
    }
}
