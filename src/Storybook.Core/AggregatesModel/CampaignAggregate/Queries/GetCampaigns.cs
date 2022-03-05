using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Storybook.Core;
using Storybook.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Storybook.Core
{

    public class GetCampaignsRequest: IRequest<GetCampaignsResponse> { }
    public class GetCampaignsResponse: ResponseBase
    {
        public List<CampaignDto> Campaigns { get; set; }
    }
    public class GetCampaignsHandler: IRequestHandler<GetCampaignsRequest, GetCampaignsResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<GetCampaignsHandler> _logger;
    
        public GetCampaignsHandler(IStorybookDbContext context, ILogger<GetCampaignsHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetCampaignsResponse> Handle(GetCampaignsRequest request, CancellationToken cancellationToken)
        {
            return new () {
                Campaigns = await _context.Campaigns.AsNoTracking().ToDtosAsync(cancellationToken)
            };
        }
        
    }

}
