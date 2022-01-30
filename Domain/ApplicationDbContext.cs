using Domain.Config;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Payment> Payments { get; private set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PaymentConfiguration());
        }
    }
}
