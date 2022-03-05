using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Storybook.Core;
using Storybook.Core.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Storybook.Core
{

    public class RemoveCampaignRequest: IRequest<RemoveCampaignResponse>
    {
        public int CampaignId { get; set; }
    }
    public class RemoveCampaignResponse: ResponseBase
    {
        public CampaignDto Campaign { get; set; }
    }
    public class RemoveCampaignHandler: IRequestHandler<RemoveCampaignRequest, RemoveCampaignResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<RemoveCampaignHandler> _logger;
    
        public RemoveCampaignHandler(IStorybookDbContext context, ILogger<RemoveCampaignHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<RemoveCampaignResponse> Handle(RemoveCampaignRequest request, CancellationToken cancellationToken)
        {
            var campaign = await _context.Campaigns.FindAsync(request.CampaignId);
            
            _context.Campaigns.Remove(campaign);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                Campaign = campaign.ToDto()
            };
        }
        
    }

}
