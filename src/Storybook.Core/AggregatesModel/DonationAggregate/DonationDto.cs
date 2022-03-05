using System;

namespace Storybook.Core
{
    public class DonationDto
    {
        public int? DonationId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethodName { get; set; }
        public bool IsPerpetual { get; set; }
    }
}
