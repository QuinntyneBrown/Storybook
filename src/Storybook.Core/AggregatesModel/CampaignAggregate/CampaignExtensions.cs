using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Storybook.Core
{
    public static class CampaignExtensions
    {
        public static CampaignDto ToDto(this Campaign campaign)
        {
            return new ()
            {
                CampaignId = campaign.CampaignId,
            };
        }
        
        public static async Task<List<CampaignDto>> ToDtosAsync(this IQueryable<Campaign> campaigns, CancellationToken cancellationToken)
        {
            return await campaigns.Select(x => x.ToDto()).ToListAsync(cancellationToken);
        }
        
        public static List<CampaignDto> ToDtos(this IEnumerable<Campaign> campaigns)
        {
            return campaigns.Select(x => x.ToDto()).ToList();
        }
        
    }
}
