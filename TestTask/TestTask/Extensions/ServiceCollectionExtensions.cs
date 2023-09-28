using Microsoft.EntityFrameworkCore;
using TestTask.Data;

namespace TestTask.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection @this, WebApplicationBuilder builder)
        {
            @this.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies()
            );

            return @this;
        }
    }
}
