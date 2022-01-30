using Domain.ValueObjects;
using Shared.Translations.Exceptions;
using Xunit;

namespace UnitTests
{
    public class ValueObjectsTests
    {
        [Fact]
        public void Throws_Exception_When_Invalid_Phone_Format()
        {
            Assert.Throws<TranslatableException>(() => new Phone("87078774213"));
        }

        [Fact]
        public void Throws_Exception_When_Amount_More_100000()
        {
            Assert.Throws<TranslatableException>(() => new Amount(101000));
        }

        [Fact]
        public void Throws_Exception_When_Amount_Less_100()
        {
            Assert.Throws<TranslatableException>(() => new Amount(99));
        }
    }
}
