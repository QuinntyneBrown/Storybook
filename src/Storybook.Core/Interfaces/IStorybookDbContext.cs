using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Storybook.Core.Interfaces
{
    public interface IStorybookDbContext
    {
        DbSet<Donation> Donations { get; }
        DbSet<Campaign> Campaigns { get; }
        DbSet<Employee> Employees { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
