using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shared.Translations.Extensions;
using Shared.Translations.Models;
using System.Text;

namespace Shared.Translations.Services
{
    public class JsonFileTranslateService
    {
        private readonly Dictionary<string, Dictionary<string, string>> _translations;
        private readonly JsonFileTranslateServiceOptions _options;
        private readonly ILogger<TranslatableObject> _logger;

        public JsonFileTranslateService(IOptions<JsonFileTranslateServiceOptions> options, ILogger<TranslatableObject> logger)
        {
            _options = options.Value;
            _logger = logger;
            _translations = CreateTranslations();
        }

        public string Translate(string localizationKey, Language language, params object[] formatArgs)
        {
            _logger.LogError(localizationKey, formatArgs);
            var translation = _translations[language.GetCode()].TryGetValue(localizationKey, out var value)
                ? value
                : _translations[Language.Kazakh.GetCode()][localizationKey];
            var res = string.Format(translation, formatArgs);
            return res;
        }

        public string Translate(TranslatableObject translatableObject, Language language, params object[] formatArgs)
        {
            return Translate(translatableObject.LocaliationKey, language, formatArgs);
        }

        private Dictionary<string, Dictionary<string, string>> CreateTranslations()
        {
            var translations = new Dictionary<string, Dictionary<string, string>>();


            foreach (var file in _options.TranslationFiles)
            {
                string content = File.ReadAllText(Path.Combine(file.Path.Prepend(AppDomain.CurrentDomain.BaseDirectory).ToArray()), Encoding.GetEncoding(65001));
                var keyValue = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);

                translations[file.Language] = keyValue;
            }

            return translations;
        }
    }

    public class JsonFileTranslateServiceOptions
    {
        public List<TranslationFile> TranslationFiles { get; set; } = new List<TranslationFile>();
    }

    public class TranslationFile
    {
        public List<string> Path { get; set; }
        public string Language { get; set; }
    }
}
