namespace Domain.ValueObjects
{
    public abstract class ValueObject<T> : IEquatable<T>, IEquatable<ValueObject<T>>
           where T : ValueObject<T>
    {
        protected abstract IEnumerable<object> GetAtomicValues();

        protected static bool EqualOperator(ValueObject<T> left, ValueObject<T> right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }

            return ReferenceEquals(left, right) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject<T> left, ValueObject<T> right)
        {
            return !EqualOperator(left, right);
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            return EqualOperator(left, right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return NotEqualOperator(left, right);
        }

        public override bool Equals(object obj)
        {
            if (obj is T other)
            {
                return Equals(other);
            }

            return false;
        }

        public bool Equals(ValueObject<T> other)
        {
            return Equals((T)other);
        }

        public bool Equals(T other)
        {
            if (other is null) return false;

            return other
                .GetAtomicValues()
                .SequenceEqual(GetAtomicValues());
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => HashCode.Combine(x, y));
        }
    }
}
