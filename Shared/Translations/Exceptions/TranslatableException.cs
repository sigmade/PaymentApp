namespace Shared.Translations.Exceptions
{
    public class TranslatableException : Exception
    {
        public TranslatableException(string localizationKey, params object[] formatArgs) : base(localizationKey)
        {
            LocalizationKey = localizationKey;
            FormatArgs = formatArgs;
        }

        public TranslatableException(string localizationKey, Exception innerException, params object[] formatArgs) : base(localizationKey, innerException)
        {
            LocalizationKey = localizationKey;
            FormatArgs = formatArgs;
        }

        public string LocalizationKey { get; }
        public object[] FormatArgs { get; }
    }
}
