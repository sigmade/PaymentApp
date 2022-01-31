using Application.Common;
using Application.Models;
using Domain.Models;

namespace Application.MoblieProviders
{
    public abstract class Provider : Enumeration<Provider>
    {
        private readonly string[] _possibleCodes;

        protected Provider(int key, string name, string[] possibleCodes) : base(key, name)
        {
            _possibleCodes = possibleCodes;
        }

        public static bool TryDefineCode(string code, out Provider? provider)
        {
            provider = Values.FirstOrDefault(value => value._possibleCodes.Contains(code)) ?? null;

            return provider != null;
        }

        public static Provider Beeline { get; } =
            new Beeline(0, nameof(Beeline), new[] { "777", "705" });

        public static Provider Active { get; } =
            new Active(2, nameof(Active), new[] { "701" });

        public static Provider Altel { get; } =
            new Altel(3, nameof(Altel), new[] { "700", "708" });

        public static Provider Tele2 { get; } =
            new Tele2(1, nameof(Tele2), new[] { "707", "747" });

        public abstract Task<ProviderResponse> SendPay(Payment payment, CancellationToken cancellationToken);
    }
}