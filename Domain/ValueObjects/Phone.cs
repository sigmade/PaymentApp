using Shared.Translations.Constants;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Phone : ValueObject<Phone>
    {
        public Phone(string value)
        {
            if (!Regex.Match(value, @"^(\+7[0-9]{10})$").Success)
            {
                TranslatableObjects.InvalidPhoneFormat.Throw();
            }

            Value = value;
        }

        public string Value { get; }

        public string ProviderPrefix()
        {
            return Value.Substring(2, 3);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static implicit operator string(Phone balance) => balance.Value;
        public static implicit operator Phone(string balance) => new(balance);
    }
}
