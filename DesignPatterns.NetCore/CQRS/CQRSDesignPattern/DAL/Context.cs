using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CQRSDesignPattern.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-BHKTJJE\\SQLEXPRESS01; initial catalog = DesingPattern2; integrated security = true;");
        }

        public DbSet<Product> Products { get; set; }

    }
}
