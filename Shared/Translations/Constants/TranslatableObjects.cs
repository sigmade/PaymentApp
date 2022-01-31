using Shared.Translations.Models;

namespace Shared.Translations.Constants
{
    public static class TranslatableObjects
    {
        public static TranslatableObject UnknownProvider { get; } = new TranslatableObject(nameof(UnknownProvider));
        public static TranslatableObject InvalidPhoneFormat { get; } = new TranslatableObject(nameof(InvalidPhoneFormat));
        public static TranslatableObject ProviderError { get; } = new TranslatableObject(nameof(ProviderError));
        public static TranslatableObject MinAmount { get; } = new TranslatableObject(nameof(MinAmount));
        public static TranslatableObject MaxAmount { get; } = new TranslatableObject(nameof(MaxAmount));
    }
}
