using Account.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Account.API.Data
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.HasIndex(e => e.PhoneNumber)
                    .IsUnique();
            });
        }
    }
}
