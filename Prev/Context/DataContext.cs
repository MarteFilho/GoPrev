using Microsoft.EntityFrameworkCore;
using Prev.Models;

namespace Prev.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
