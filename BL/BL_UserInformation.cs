using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using DA.Repositories;

namespace BL
{
    public class BL_UserInformation : DA_UserInformation
    {
        public string firstName, lastName, email, password;
        public int roleID;

        public bool BL_Insert()
        {
            if (AlphabeticValidation(this.firstName) && AlphabeticValidation(this.lastName) && BL_EmailValidation(email))
            {
                DA_Insert(firstName, lastName, email, password, roleID);

                return true;
            }

            return false;
        }

        private bool BL_EmailValidation(string email)
        {
            if (base.DA_EmailValidation(this.email) == false)
                return true;

            return false;
        }

        private bool AlphabeticValidation(string name)
        {
            var str = name.Trim();

            return Regex.IsMatch(str, @"^[\p{L} \.\-]+$");
        }
    }
}
