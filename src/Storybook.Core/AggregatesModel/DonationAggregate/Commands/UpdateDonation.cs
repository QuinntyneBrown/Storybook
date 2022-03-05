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

    public class UpdateDonationValidator: AbstractValidator<UpdateDonationRequest>
    {
        public UpdateDonationValidator()
        {
            RuleFor(request => request.Donation).NotNull();
            RuleFor(request => request.Donation).SetValidator(new DonationValidator());
        }
    
    }
    public class UpdateDonationRequest: IRequest<UpdateDonationResponse>
    {
        public DonationDto Donation { get; set; }
    }
    public class UpdateDonationResponse: ResponseBase
    {
        public DonationDto Donation { get; set; }
    }
    public class UpdateDonationHandler: IRequestHandler<UpdateDonationRequest, UpdateDonationResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<UpdateDonationHandler> _logger;
    
        public UpdateDonationHandler(IStorybookDbContext context, ILogger<UpdateDonationHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<UpdateDonationResponse> Handle(UpdateDonationRequest request, CancellationToken cancellationToken)
        {
            var donation = await _context.Donations.SingleAsync(x => x.DonationId == request.Donation.DonationId);
            
            donation.Amount = request.Donation.Amount;
            donation.PaymentMethodName = request.Donation.PaymentMethodName;
            donation.IsPerpetual = request.Donation.IsPerpetual;
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                Donation = donation.ToDto()
            };
        }
        
    }

}
