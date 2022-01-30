using Domain.ValueObjects;

namespace Domain.Dto
{
    public class PaymentDto
    {
        public Phone Phone { get; set; }
        public Amount Amount { get; set; }
    }
}
