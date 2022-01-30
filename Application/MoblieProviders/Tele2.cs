using Domain.Dto;

namespace Application.MoblieProviders
{
    public class Tele2 : ProviderBase
    {
        public Tele2(int key, string name, string[] possibleCodes)
            : base(key, name, possibleCodes)
        {
        }

        public async override Task<string> SendPay(PaymentDto payment, CancellationToken cancellationToken)
        {
            return "Tele2 success";
        }
    }
}