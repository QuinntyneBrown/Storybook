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

    public class UpdateCampaignValidator: AbstractValidator<UpdateCampaignRequest>
    {
        public UpdateCampaignValidator()
        {
            RuleFor(request => request.Campaign).NotNull();
            RuleFor(request => request.Campaign).SetValidator(new CampaignValidator());
        }
    
    }
    public class UpdateCampaignRequest: IRequest<UpdateCampaignResponse>
    {
        public CampaignDto Campaign { get; set; }
    }
    public class UpdateCampaignResponse: ResponseBase
    {
        public CampaignDto Campaign { get; set; }
    }
    public class UpdateCampaignHandler: IRequestHandler<UpdateCampaignRequest, UpdateCampaignResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<UpdateCampaignHandler> _logger;
    
        public UpdateCampaignHandler(IStorybookDbContext context, ILogger<UpdateCampaignHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<UpdateCampaignResponse> Handle(UpdateCampaignRequest request, CancellationToken cancellationToken)
        {
            var campaign = await _context.Campaigns.SingleAsync(x => x.CampaignId == request.Campaign.CampaignId);
            
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                Campaign = campaign.ToDto()
            };
        }
        
    }

}
