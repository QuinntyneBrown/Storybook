using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Storybook.Core;
using Storybook.Core.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Storybook.Core
{

    public class CreateCampaignValidator: AbstractValidator<CreateCampaignRequest>
    {
        public CreateCampaignValidator()
        {
            RuleFor(request => request.Campaign).NotNull();
            RuleFor(request => request.Campaign).SetValidator(new CampaignValidator());
        }
    
    }
    public class CreateCampaignRequest: IRequest<CreateCampaignResponse>
    {
        public CampaignDto Campaign { get; set; }
    }
    public class CreateCampaignResponse: ResponseBase
    {
        public CampaignDto Campaign { get; set; }
    }
    public class CreateCampaignHandler: IRequestHandler<CreateCampaignRequest, CreateCampaignResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<CreateCampaignHandler> _logger;
    
        public CreateCampaignHandler(IStorybookDbContext context, ILogger<CreateCampaignHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<CreateCampaignResponse> Handle(CreateCampaignRequest request, CancellationToken cancellationToken)
        {
            var campaign = new Campaign();
            
            _context.Campaigns.Add(campaign);
            
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                Campaign = campaign.ToDto()
            };
        }
        
    }

}
