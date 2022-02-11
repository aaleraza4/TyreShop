using Microsoft.EntityFrameworkCore;
using Tyre.Data.Entities;

namespace Tyre.Data.DbContexts
{
    public class QtyrePlusDbContext : DbContext
    {
        public QtyrePlusDbContext(DbContextOptions<QtyrePlusDbContext> options) : base(options)
        {
                
        }
        public DbSet<SuperadminAccount> superadminAccounts { get; set; }
        public DbSet<BannerImage> bannerImages { get; set; }
    }
}
