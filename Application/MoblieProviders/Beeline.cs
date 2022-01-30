using Domain.Dto;

namespace Application.MoblieProviders
{
    public class Beeline : ProviderBase
    {
        public Beeline(int key, string name, string[] possibleCodes)
            : base(key, name, possibleCodes)
        {
        }

        public async override Task<string> SendPay(PaymentDto payment, CancellationToken cancellationToken)
        {
            return "Beeline success";
        }
    }
}