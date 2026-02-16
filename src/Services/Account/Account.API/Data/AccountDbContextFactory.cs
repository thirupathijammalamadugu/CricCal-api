using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Account.API.Data
{
    public class AccountDbContextFactory : IDesignTimeDbContextFactory<AccountDbContext>
    {
        public AccountDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountDbContext>();
            
            // Use a default connection string for design-time
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=AccountDb;User Id=sa;Password=#@Swamy#@;TrustServerCertificate=true;");
            
            return new AccountDbContext(optionsBuilder.Options);
        }
    }
}