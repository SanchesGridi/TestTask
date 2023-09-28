using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<UserService> logger;

        public UserService(ApplicationDbContext context, ILogger<UserService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<User> GetUser()
        {
            try
            {
                var users = await context.Users.ToListAsync();
                var user = users.MaxBy(u => u.Orders.Sum(o => o.Quantity));
                return user!;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                var users = await context.Users.Where(x => x.Status == UserStatus.Inactive).ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
