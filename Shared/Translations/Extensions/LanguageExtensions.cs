using Shared.Translations.Models;

namespace Shared.Translations.Extensions
{
    public static class LanguageExtensions
    {
        public static string GetCode(this Language language)
        {
            return language switch
            {
                Language.Kazakh => "kz",
                Language.Russian => "ru",
                _ => throw new ArgumentOutOfRangeException(nameof(language)),
            };
        }
    }
}
