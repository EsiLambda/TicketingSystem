using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Models;
using DA.Repositories;

namespace DA.Repositories
{
    public class DA_AdminTicket
    {
        protected void DA_Insert(Guid userTicketID, string[] strInfo)
        {
            DatabaseContext db = new DatabaseContext();
            AdminTicket adminTicket = new AdminTicket();

            adminTicket.UserTicketID = userTicketID;
            adminTicket.Topic = strInfo[0];
            adminTicket.Section = strInfo[1];
            adminTicket.Status = strInfo[2];
            adminTicket.RegistrationDate = DateTime.Now;
            adminTicket.LastUpdate = DateTime.Now;

            db.AdminTicket.Add(adminTicket);
            db.SaveChanges();
        }

        protected void DA_UpdateAdminTicket(Guid id)
        {
            DatabaseContext db = new DatabaseContext();

            var tick = db.AdminTicket.Where(x => x.UserTicketID == id).First();

            tick.LastUpdate = DateTime.Now;

            db.SaveChanges();
        }

        protected void DA_SendAdminAnswer(Guid id, string da_answer)
        {
            DatabaseContext db = new DatabaseContext();

            var adminTicket = db.AdminTicket
                .Where(x => x.UserTicketID == id)
                .OrderBy(x => x.RegistrationDate)
                .OrderByDescending(x => x.LastUpdate)
                .First();

            adminTicket.Description = da_answer;
            adminTicket.Status = "پاسخ داده شده";

            db.SaveChanges();
        }

        protected List<AdminTicket> DA_ShowAdminTickets(string email)
        {
            DatabaseContext db = new DatabaseContext();
            List<AdminTicket> adminTicket = new List<AdminTicket>();

            var userIDs = db.UserTicket
                    .Where(x => x.UserInformationID == email)
                    .OrderByDescending(y => y.Date)
                    .Select(y => new { ID = y.ID }).ToList();

            foreach (var rec in userIDs)
            {
                adminTicket.Add(db.AdminTicket
                    .Where(x => x.UserTicketID == rec.ID)
                    .FirstOrDefault());
            }

            return adminTicket;
        }
    }
}
