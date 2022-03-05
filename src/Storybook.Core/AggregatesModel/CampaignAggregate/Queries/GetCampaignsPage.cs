using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Storybook.Core;
using Storybook.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Storybook.Core
{

    public class GetCampaignsPageRequest: IRequest<GetCampaignsPageResponse>
    {
        public int PageSize { get; set; }
        public int Index { get; set; }
    }
    public class GetCampaignsPageResponse: ResponseBase
    {
        public int Length { get; set; }
        public List<CampaignDto> Entities { get; set; }
    }
    public class GetCampaignsPageHandler: IRequestHandler<GetCampaignsPageRequest, GetCampaignsPageResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<GetCampaignsPageHandler> _logger;
    
        public GetCampaignsPageHandler(IStorybookDbContext context, ILogger<GetCampaignsPageHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetCampaignsPageResponse> Handle(GetCampaignsPageRequest request, CancellationToken cancellationToken)
        {
            var query = from campaign in _context.Campaigns
                select campaign;
            
            var length = await _context.Campaigns.AsNoTracking().CountAsync();
            
            var campaigns = await query.Page(request.Index, request.PageSize).AsNoTracking()
                .Select(x => x.ToDto()).ToListAsync();
            
            return new ()
            {
                Length = length,
                Entities = campaigns
            };
        }
        
    }

}
