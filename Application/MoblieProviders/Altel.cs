using Domain.Dto;

namespace Application.MoblieProviders
{
    public class Altel : ProviderBase
    {
        public Altel(int key, string name, string[] possibleCodes)
            : base(key, name, possibleCodes)
        {
        }

        public async override Task<string> SendPay(PaymentDto payment, CancellationToken cancellationToken)
        {
            return "Altel success";
        }
    }
}