using Domain.Models;

namespace Domain.Services
{
    public interface IPaymentService
    {
        Task Handle(Payment payment, CancellationToken cancellationToken);
    }
}
