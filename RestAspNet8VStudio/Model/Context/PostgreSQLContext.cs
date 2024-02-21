using Microsoft.EntityFrameworkCore;

namespace RestAspNet8VStudio.Model.Context
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext()
        {

        }
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

    }
}
