using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA.Models;

namespace DA.Repositories
{
    public class DA_UserAuthentication
    {
        protected bool DA_AdminLogIn(string email, string password)
        {
            DatabaseContext db = new Models.DatabaseContext();

            return db.UserInformation.Any(r => r.Email == email && r.Password == password);
        }

        protected int DA_Role(string email)
        {
            DatabaseContext db = new Models.DatabaseContext();

            var rID = db.UserInformation.Where(r => r.Email == email).Select(x => new { RoleID = x.RoleID}).ToList();

            return rID[0].RoleID;
        }
    }
}
