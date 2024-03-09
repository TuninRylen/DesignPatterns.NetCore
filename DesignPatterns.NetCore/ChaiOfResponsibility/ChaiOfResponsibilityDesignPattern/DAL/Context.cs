using Microsoft.EntityFrameworkCore;

namespace ChaiOfResponsibilityDesignPattern.DAL
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-BHKTJJE\\SQLEXPRESS01; initial catalog = DesingPattern1; integrated security = true;");
        }

        public DbSet<CustomerProcess> CustomerProcess { get; set; }

    }
}