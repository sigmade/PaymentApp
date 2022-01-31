using Application.Models;
using Domain.Models;

namespace Application.MoblieProviders
{
    public class Altel : Provider
    {
        public Altel(int key, string name, string[] possibleCodes)
            : base(key, name, possibleCodes)
        {
        }

        public async override Task<ProviderResponse> SendPay(Payment payment, CancellationToken cancellationToken)
        {
            return new() { Provider = Provider.Altel, Status = ResponseStatus.Success };
        }
    }
}