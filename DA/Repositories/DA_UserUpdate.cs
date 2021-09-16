using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Repositories;

namespace DA.Repositories
{
    public class DA_UserUpdate
    {
        protected void DA_UpdateUser(string email, string password)
        {
            Models.DatabaseContext db = new Models.DatabaseContext();

            var user = db.UserInformation.Where(x => x.Email == email).First();

            user.Password = password;

            db.SaveChanges();
        }

        protected List<Models.UserInformation> DA_ShowUpdatedUsers()
        {
            Models.DatabaseContext db = new Models.DatabaseContext();

            return db.UserInformation.Where(x => x.RoleID != 2).ToList();
        }
    }
}
