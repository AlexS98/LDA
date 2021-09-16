using Microsoft.EntityFrameworkCore;

using WebApplication.Domain.Models;

namespace WebApplication.Domain
{
    public class DbService : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbService(DbContextOptions<DbService> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
