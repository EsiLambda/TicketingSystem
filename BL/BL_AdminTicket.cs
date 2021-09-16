using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Models;
using DA.Repositories;

namespace BL
{
    public class BL_AdminTicket : DA_AdminTicket
    {
        public Guid id, userTicketID;
        public string topic, section, status, adminAnswer;

        public void BL_Insert()
        {
            string[] strInfo = new[] { topic, section, status };

            DA_Insert(userTicketID, strInfo);
        }

        public void BL_UpdateAdminTicket(Guid id)
        {
            DA_UpdateAdminTicket(id);
        }

        public void BL_SendAdminAnswer()
        {
            DA_SendAdminAnswer(id, adminAnswer);
        }

        public List<AdminTicket> BL_ShowAdminTickets(string emailAuth)
        {
            return DA_ShowAdminTickets(emailAuth);
        }
    }
}
