using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Model.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        public DbSet<EmailLog> Emails { get; set; }
    }
}
