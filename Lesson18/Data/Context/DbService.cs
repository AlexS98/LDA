using Lesson18.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace Lesson18.Data.Context
{
    public class DbService : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserData> UserData { get; set; }

        public DbService(DbContextOptions<DbService> options) : base(options)
        {

        }
    }
}
