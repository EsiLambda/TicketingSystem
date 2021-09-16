using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace tblDepartment.Models
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        static DatabaseContext()
        {
            System.Data.Entity.Database.SetInitializer
                (new System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        public DbSet<Department> Department { get; set; }
    }
}
