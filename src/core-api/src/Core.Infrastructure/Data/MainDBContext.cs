using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Core.Infrastructure.Data
{
    public class MainDBContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}