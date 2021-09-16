using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Models;
using DA.Repositories;

namespace DA.Repositories
{
    public class DA_UserTicket
    {
        protected void DA_Insert(string[] strInfo)
        {
            DatabaseContext db = new DatabaseContext();
            UserTicket userTicket = new UserTicket();
            
            userTicket.UserInformationID = strInfo[0];
            userTicket.Topic = strInfo[1];
            userTicket.Section = strInfo[2];
            userTicket.Importance = strInfo[3];
            userTicket.Description = strInfo[4];
            userTicket.Date = DateTime.Now;

            db.UserTicket.Add(userTicket);
            db.SaveChanges();
        }

        protected void DA_Update(Guid id, string[] strInfo)
        {
            DatabaseContext db = new DatabaseContext();

            var user = db.UserTicket.Where(x => x.ID == id).First();
            
            user.UserInformationID = strInfo[0];
            user.Topic = strInfo[1];
            user.Section = strInfo[2];
            user.Importance = strInfo[3];
            user.Description = strInfo[4];

            db.SaveChanges();
        }

        public void DA_Delete(Guid id)
        {
            DatabaseContext db = new DatabaseContext();

            var ticket = db.UserTicket.Where(x => x.ID == id).First();

            db.UserTicket.Remove(ticket);

            db.SaveChanges();
        }

        protected Guid DA_GetUserID(string email)
        {
            DatabaseContext db = new DatabaseContext();

            Guid id = db.UserTicket
                .Where(x => x.UserInformationID == email)
                .OrderByDescending(y => y.Date)
                .First().ID;

            return id;
        }

        protected object DA_ShowUserTicket(string email)
        {
            DatabaseContext db = new DatabaseContext();
            
            var fullName = db.UserTicket
                .Where(e => e.UserInformationID == email)
                .Join(db.UserInformation,
                x => x.UserInformationID, y => y.Email,
                (x, y) => new
                { y.FirstName, y.LastName, x.UserInformationID, x.Topic, x.Section, x.Importance, x.Date, x.Description })
                .ToList();

            return fullName;
        }

        protected object DA_ShowAllTickets()
        {
            DatabaseContext db = new DatabaseContext();

            var fullName = db.UserTicket
                .Join(db.UserInformation,
                x => x.UserInformationID, y => y.Email,
                (x, y) => new
                { x.ID ,y.FirstName, y.LastName, x.UserInformationID, x.Topic, x.Section, x.Importance, x.Date, x.Description })
                .OrderByDescending(d => d.Date)
                .ToList();

            return fullName;
        }

        protected List<UserInformation> DA_SelectDeafaultInfo(string email)
        {
            DatabaseContext db = new DatabaseContext();

            return db.UserInformation
                .Where(x => x.Email == email)
                .ToList();


        }
    }
}
