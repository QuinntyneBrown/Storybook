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

    public class GetDonationByIdRequest: IRequest<GetDonationByIdResponse>
    {
        public int DonationId { get; set; }
    }
    public class GetDonationByIdResponse: ResponseBase
    {
        public DonationDto Donation { get; set; }
    }
    public class GetDonationByIdHandler: IRequestHandler<GetDonationByIdRequest, GetDonationByIdResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<GetDonationByIdHandler> _logger;
    
        public GetDonationByIdHandler(IStorybookDbContext context, ILogger<GetDonationByIdHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetDonationByIdResponse> Handle(GetDonationByIdRequest request, CancellationToken cancellationToken)
        {
            return new () {
                Donation = (await _context.Donations.AsNoTracking().SingleOrDefaultAsync(x => x.DonationId == request.DonationId)).ToDto()
            };
        }
        
    }

}
