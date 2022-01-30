using Shared.Translations.Exceptions;

namespace Shared.Translations.Models
{
    public class TranslatableObject
    {
        public TranslatableObject(string localiationKey)
        {
            LocaliationKey = localiationKey ?? throw new ArgumentNullException(nameof(localiationKey));
        }

        public string LocaliationKey { get; }

        public void Throw(params object[] formatArgs)
        {
            throw AsException(formatArgs);
        }

        public void Throw(Exception innerException, params object[] formatArgs)
        {
            throw AsException(innerException, formatArgs);
        }

        public TranslatableException AsException(params object[] formatArgs)
        {
            return new TranslatableException(LocaliationKey, formatArgs);
        }

        public TranslatableException AsException(Exception innerException, params object[] formatArgs)
        {
            return new TranslatableException(LocaliationKey, innerException, formatArgs);
        }
    }
}
