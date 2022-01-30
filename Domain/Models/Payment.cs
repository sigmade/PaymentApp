using Domain.Dto;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Models
{
    public class Payment
    {
        private Payment() { }

        public Payment(
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

        public static Payment New(PaymentDto paymentDto)
        {
            return new(Guid.NewGuid(), paymentDto.Phone, paymentDto.Amount, TransactionStatus.Pending,
                DateTimeOffset.UtcNow);
        }
    }
}
