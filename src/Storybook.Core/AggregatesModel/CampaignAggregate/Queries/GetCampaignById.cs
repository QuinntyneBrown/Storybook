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

    public class GetCampaignByIdRequest: IRequest<GetCampaignByIdResponse>
    {
        public int CampaignId { get; set; }
    }
    public class GetCampaignByIdResponse: ResponseBase
    {
        public CampaignDto Campaign { get; set; }
    }
    public class GetCampaignByIdHandler: IRequestHandler<GetCampaignByIdRequest, GetCampaignByIdResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<GetCampaignByIdHandler> _logger;
    
        public GetCampaignByIdHandler(IStorybookDbContext context, ILogger<GetCampaignByIdHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetCampaignByIdResponse> Handle(GetCampaignByIdRequest request, CancellationToken cancellationToken)
        {
            return new () {
                Campaign = (await _context.Campaigns.AsNoTracking().SingleOrDefaultAsync(x => x.CampaignId == request.CampaignId)).ToDto()
            };
        }
        
    }

}
