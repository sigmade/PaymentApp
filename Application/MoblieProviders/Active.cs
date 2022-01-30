using Application.Models;
using Domain.Dto;

namespace Application.MoblieProviders
{
    public class Active : Provider
    {
        public Active(int key, string name, string[] possibleCodes)
            : base(key, name, possibleCodes)
        {
        }

        public async override Task<ProviderResponse> SendPay(PaymentDto payment, CancellationToken cancellationToken)
        {
            return new() { Provider = Provider.Active, Status = ResponseStatus.Success };
        }
    }
}