using Application.Models;
using Domain.Models;

namespace Application.MoblieProviders
{
    public class Tele2 : Provider
    {
        public Tele2(int key, string name, string[] possibleCodes)
            : base(key, name, possibleCodes)
        {
        }

        public async override Task<ProviderResponse> SendPay(Payment payment, CancellationToken cancellationToken)
        {
            return new() { Provider = Provider.Tele2, Status = ResponseStatus.Success };
        }
    }
}