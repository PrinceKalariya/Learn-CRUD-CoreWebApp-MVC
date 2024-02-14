using Learn_CRUD_CoreWebApp_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn_CRUD_CoreWebApp_MVC.Context
{
    public class ProviderDbContext : DbContext
    {
        public ProviderDbContext(DbContextOptions<ProviderDbContext> contextOptions) : base(contextOptions) { }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<Services> Services { get; set; }

        public DbSet<ProviderServices> ProviderServices { get; set; }
    }
}
