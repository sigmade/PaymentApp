using Shared.Translations.Constants;

namespace Domain.ValueObjects
{
    public class Amount : ValueObject<Amount>
    {
        public Amount(int value)
        {
            if (value < 100)
            {
                TranslatableObjects.MinAmount.Throw();
            }
            if (value > 100000)
            {
                TranslatableObjects.MaxAmount.Throw();
            }

            Value = value;
        }

        public int Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static implicit operator int(Amount balance) => balance.Value;
        public static implicit operator Amount(int balance) => new(balance);
    }
}
