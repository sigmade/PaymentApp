using Domain.Models;
using Domain.ValueObjects;
using Infrastructure.Enums;

namespace Infrastructure.Models
{
    public class PaymentEntity
    {
        private PaymentEntity() { }

        public PaymentEntity(
            Guid id,
            Phone phone,
            Amount amount,
            TransactionStatus status,
            DateTimeOffset dateCreate)
        {
            Id = id;
            Phone = phone;
            Amount = amount;
            Status = status;
            DateCreate = dateCreate;
        }

        public Guid Id { get; private set; }
        public Phone Phone { get; private set; }
        public Amount Amount { get; private set; }
        public TransactionStatus Status { get; private set; }
        public DateTimeOffset DateCreate { get; private set; }
        public DateTimeOffset? DateProcessed { get; private set; }

        public static PaymentEntity New(Payment payment)
        {
            return new(Guid.NewGuid(), payment.Phone, payment.Amount, TransactionStatus.Pending,
                DateTimeOffset.UtcNow);
        }
    }
}
