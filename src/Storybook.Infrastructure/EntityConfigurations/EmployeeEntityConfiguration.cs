using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storybook.Core;

namespace Storybook.Infrastructure.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder.Property(e => e.EmployeeId).HasConversion(new EmployeeId.EfCoreValueConverter());
        }
    }
}
