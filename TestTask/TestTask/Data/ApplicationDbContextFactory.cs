using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TestTask.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
              // .UseSqlServer("Data Source=.;Initial Catalog=IfortexTestTask;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
              .UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=IfortexTestTask;Trusted_Connection=True")
              .UseLazyLoadingProxies();

            return new(builder.Options);
        }
    }
}
