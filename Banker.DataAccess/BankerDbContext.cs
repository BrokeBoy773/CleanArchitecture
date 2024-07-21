using Banker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banker.DataAccess
{
    public class BankerDbContext : DbContext
    {
        public DbSet<BankEntity> Banks { get; set; }

        public BankerDbContext(DbContextOptions<BankerDbContext> options) : base(options)
        {

        }
    }
}
