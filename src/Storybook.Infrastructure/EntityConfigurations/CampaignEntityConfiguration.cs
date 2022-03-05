using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Storybook.Core;

namespace Storybook.Infrastructure.EntityConfigurations
{
    public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            //builder.Property(e => e.CampaignId).HasConversion(new CampaignId.EfCoreValueConverter());
        }
    }
}
