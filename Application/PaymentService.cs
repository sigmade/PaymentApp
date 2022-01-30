using Application.MoblieProviders;
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

            _ = await SendToProvider(payment, cancellationToken); //TODO: Handle result

            await SaveInDb(payment, cancellationToken);
        }

        public async Task<string> SendToProvider(PaymentDto payment, CancellationToken cancellationToken)
        {
            if (!ProviderBase.TryDefineCode(payment.Phone.ProviderPrefix(), out var provider))
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
