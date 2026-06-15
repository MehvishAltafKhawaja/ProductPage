using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class UserdbContext:DbContext
    {
        public UserdbContext(DbContextOptions<UserdbContext> options)
           : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
