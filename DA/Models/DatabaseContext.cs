using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace DA.Models
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("TicketingSystem")
        {
        }

        static DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>
                (new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        public DbSet<UserInformation> UserInformation { get; set; }
        public DbSet<AdminTicket> AdminTicket { get; set; }
        public DbSet<UserTicket> UserTicket { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}
