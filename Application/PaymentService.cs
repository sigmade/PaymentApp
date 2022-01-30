using Application.MoblieProviders;
using Application.Models;
using Domain;
using Domain.Dto;
using Domain.Models;
using Domain.ValueObjects;
using Shared.Translations.Constants;

namespace Application
{
    public class PaymentService
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PaymentService() { }

        public async Task Handle(Phone phone, Amount amount, CancellationToken cancellationToken)
        {
            var payment = new PaymentDto { Phone = phone, Amount = amount };

            var providerResponse = await SendToProvider(payment, cancellationToken); //TODO: Handle result

            if (providerResponse.Status != ResponseStatus.Success)
            {
                TranslatableObjects.UnknownProvider.Throw();
            }

            await SaveInDb(payment, cancellationToken);
        }

        public async Task<ProviderResponse> SendToProvider(PaymentDto payment, CancellationToken cancellationToken)
        {
            if (!Provider.TryDefineCode(payment.Phone.ProviderPrefix(), out var provider))
            {
                TranslatableObjects.UnknownProvider.Throw();
            }

            return await provider.SendPay(payment, cancellationToken);
        }

        private async Task SaveInDb(PaymentDto payment, CancellationToken cancellationToken)
        {
            _dbContext.Payments.Add(Payment.New(payment));
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
