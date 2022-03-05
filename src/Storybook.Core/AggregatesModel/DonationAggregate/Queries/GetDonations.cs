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

    public class GetDonationsRequest: IRequest<GetDonationsResponse> { }
    public class GetDonationsResponse: ResponseBase
    {
        public List<DonationDto> Donations { get; set; }
    }
    public class GetDonationsHandler: IRequestHandler<GetDonationsRequest, GetDonationsResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<GetDonationsHandler> _logger;
    
        public GetDonationsHandler(IStorybookDbContext context, ILogger<GetDonationsHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetDonationsResponse> Handle(GetDonationsRequest request, CancellationToken cancellationToken)
        {
            return new () {
                Donations = await _context.Donations.AsNoTracking().ToDtosAsync(cancellationToken)
            };
        }
        
    }

}
