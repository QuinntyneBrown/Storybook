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

    public class RemoveDonationRequest: IRequest<RemoveDonationResponse>
    {
        public int DonationId { get; set; }
    }
    public class RemoveDonationResponse: ResponseBase
    {
        public DonationDto Donation { get; set; }
    }
    public class RemoveDonationHandler: IRequestHandler<RemoveDonationRequest, RemoveDonationResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<RemoveDonationHandler> _logger;
    
        public RemoveDonationHandler(IStorybookDbContext context, ILogger<RemoveDonationHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<RemoveDonationResponse> Handle(RemoveDonationRequest request, CancellationToken cancellationToken)
        {
            var donation = await _context.Donations.FindAsync(request.DonationId);
            
            _context.Donations.Remove(donation);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                Donation = donation.ToDto()
            };
        }
        
    }

}
