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

    public class CreateDonationValidator: AbstractValidator<CreateDonationRequest>
    {
        public CreateDonationValidator()
        {
            RuleFor(request => request.Donation).NotNull();
            RuleFor(request => request.Donation).SetValidator(new DonationValidator());
        }
    
    }
    public class CreateDonationRequest: IRequest<CreateDonationResponse>
    {
        public DonationDto Donation { get; set; }
    }
    public class CreateDonationResponse: ResponseBase
    {
        public DonationDto Donation { get; set; }
    }
    public class CreateDonationHandler: IRequestHandler<CreateDonationRequest, CreateDonationResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<CreateDonationHandler> _logger;
    
        public CreateDonationHandler(IStorybookDbContext context, ILogger<CreateDonationHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<CreateDonationResponse> Handle(CreateDonationRequest request, CancellationToken cancellationToken)
        {
            var donation = new Donation();
            
            _context.Donations.Add(donation);
            
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
