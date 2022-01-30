using Application.Common;
using Domain.Dto;

namespace Application.MoblieProviders
{
    public abstract class ProviderBase : Enumeration<ProviderBase>
    {
        private readonly string[] _possibleCodes;

        protected ProviderBase(int key, string name, string[] possibleCodes) : base(key, name)
        {
            _possibleCodes = possibleCodes;
        }

        public static bool TryDefineCode(string code, out ProviderBase? provider)
        {
            provider = Values.FirstOrDefault(value => value._possibleCodes.Contains(code)) ?? null;

            return provider != null;
        }

        public static ProviderBase Beeline { get; } =
            new Beeline(0, nameof(Beeline), new[] { "777", "705" });

        public static ProviderBase Active { get; } =
            new Active(2, nameof(Active), new[] { "701" });

        public static ProviderBase Altel { get; } =
            new Altel(3, nameof(Altel), new[] { "700", "708" });

        public static ProviderBase Tele2 { get; } =
            new Tele2(1, nameof(Tele2), new[] { "707", "747" });

        public abstract Task<string> SendPay(PaymentDto paymentDto, CancellationToken cancellationToken);
    }
}