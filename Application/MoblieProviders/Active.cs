using Domain.Dto;

namespace Application.MoblieProviders
{
    public class Active : ProviderBase
    {
        public Active(int key, string name, string[] possibleCodes)
            : base(key, name, possibleCodes)
        {
        }

        public async override Task<string> SendPay(PaymentDto payment, CancellationToken cancellationToken)
        {
            return "Active success";
        }
    }
}