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

    public class GetDonationsPageRequest: IRequest<GetDonationsPageResponse>
    {
        public int PageSize { get; set; }
        public int Index { get; set; }
    }
    public class GetDonationsPageResponse: ResponseBase
    {
        public int Length { get; set; }
        public List<DonationDto> Entities { get; set; }
    }
    public class GetDonationsPageHandler: IRequestHandler<GetDonationsPageRequest, GetDonationsPageResponse>
    {
        private readonly IStorybookDbContext _context;
        private readonly ILogger<GetDonationsPageHandler> _logger;
    
        public GetDonationsPageHandler(IStorybookDbContext context, ILogger<GetDonationsPageHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetDonationsPageResponse> Handle(GetDonationsPageRequest request, CancellationToken cancellationToken)
        {
            var query = from donation in _context.Donations
                select donation;
            
            var length = await _context.Donations.AsNoTracking().CountAsync();
            
            var donations = await query.Page(request.Index, request.PageSize).AsNoTracking()
                .Select(x => x.ToDto()).ToListAsync();
            
            return new ()
            {
                Length = length,
                Entities = donations
            };
        }
        
    }

}
