using Storybook.Core;
using Storybook.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Storybook.Infrastructure.Data
{
    public class StorybookDbContext: DbContext, IStorybookDbContext
    {
        public DbSet<Donation> Donations { get; private set; }
        public DbSet<Campaign> Campaigns { get; private set; }
        public DbSet<Employee> Employees { get; private set; }
        public StorybookDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StorybookDbContext).Assembly);
        }
        
    }
}
