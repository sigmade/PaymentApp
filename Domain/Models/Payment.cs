using Domain.ValueObjects;

namespace Domain.Models
{
    public class Payment
    {
        public Phone Phone { get; set; }
        public Amount Amount { get; set; }
    }
}
