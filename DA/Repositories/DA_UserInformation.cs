using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using DA.Models;

namespace DA.Repositories
{
    public class DA_UserInformation
    {
        protected void DA_Insert(string firstName, string lastName, string email, string password, int roleID)
        {
            DatabaseContext db = new Models.DatabaseContext();
            UserInformation userInfo = new Models.UserInformation();

            userInfo.FirstName = firstName;
            userInfo.LastName = lastName;
            userInfo.Email = email;
            userInfo.Password = password;
            userInfo.RoleID = roleID;

            db.UserInformation.Add(userInfo);
            db.SaveChanges();
        }

        protected bool DA_EmailValidation(string email)
        {
            DA.Models.DatabaseContext db = new Models.DatabaseContext();

            return db.UserInformation.Any(user => user.Email == email);
        }
    }
}
