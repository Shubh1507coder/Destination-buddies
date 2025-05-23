using Microsoft.EntityFrameworkCore;
using NewProjectMca.Models;

namespace BookingTickets.Models
{
    public class TicketDBContext : DbContext
    {
        public TicketDBContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<train> tbl_train { get; set; }
        public DbSet<bus> tbl_bus { get; set; }
        public DbSet<flight> tbl_flight { get; set; }
        public DbSet<booktrip> tbl_booktrips { get; set; }
        public DbSet<adminlogin> tbl_admin { get; set; }
        public DbSet<user> tbl_user { get; set; }
        public DbSet<contact> tbl_contact { get; set; }

   

    }
}
