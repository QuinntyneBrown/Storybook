using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Storybook.Core
{
    public static class DonationExtensions
    {
        public static DonationDto ToDto(this Donation donation)
        {
            return new ()
            {
                DonationId = donation.DonationId,
                Amount = donation.Amount,
                PaymentMethodName = donation.PaymentMethodName,
                IsPerpetual = donation.IsPerpetual,
            };
        }
        
        public static async Task<List<DonationDto>> ToDtosAsync(this IQueryable<Donation> donations, CancellationToken cancellationToken)
        {
            return await donations.Select(x => x.ToDto()).ToListAsync(cancellationToken);
        }
        
        public static List<DonationDto> ToDtos(this IEnumerable<Donation> donations)
        {
            return donations.Select(x => x.ToDto()).ToList();
        }
        
    }
}
