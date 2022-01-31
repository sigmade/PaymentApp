using Application.MoblieProviders;
using Application.Models;
using Domain.Models;
using Domain.Services;
using Infrastructure;
using Infrastructure.Models;
using Shared.Translations.Constants;

namespace Application
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PaymentService() { }

        public async Task Handle(Payment payment, CancellationToken cancellationToken)
        {
            var providerResponse = await SendToProvider(payment, cancellationToken);

            if (providerResponse.Status != ResponseStatus.Success)
            {
                TranslatableObjects.ProviderError.Throw();
            }

            await SaveInDb(payment, cancellationToken);
        }

        public async Task<ProviderResponse> SendToProvider(Payment payment, CancellationToken cancellationToken)
        {
            if (!Provider.TryDefineCode(payment.Phone.ProviderPrefix(), out var provider))
            {
                TranslatableObjects.UnknownProvider.Throw();
            }

            return await provider.SendPay(payment, cancellationToken);
        }

        private async Task SaveInDb(Payment payment, CancellationToken cancellationToken)
        {
            _dbContext.Payments.Add(PaymentEntity.New(payment));
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
