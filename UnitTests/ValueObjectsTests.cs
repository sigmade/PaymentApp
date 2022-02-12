using Domain.ValueObjects;
using Shared.Translations.Constants;
using Shared.Translations.Exceptions;
using System;
using Xunit;

namespace UnitTests
{
    public class ValueObjectsTests
    {
        [Fact]
        public void Throws_Exception_When_Invalid_Phone_Format()
        {
            var expectedMessage = nameof(TranslatableObjects.InvalidPhoneFormat);
            string? result = null;

            try
            {
                _ = new Phone("87078774213");
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            Assert.Equal(expectedMessage, result);
            Assert.Throws<TranslatableException>(() => new Phone("87078774213"));
        }

        [Fact]
        public void Throws_Exception_When_Amount_More_100000()
        {
            var expectedMessage = nameof(TranslatableObjects.MaxAmount);
            string? result = null;

            try
            {
                _ = new Amount(101000);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            Assert.Equal(expectedMessage, result);
            Assert.Throws<TranslatableException>(() => new Amount(101000));
        }

        [Fact]
        public void Throws_Exception_When_Amount_Less_100()
        {
            var expectedMessage = nameof(TranslatableObjects.MinAmount);
            string? result = null;

            try
            {
                _ = new Amount(99);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            Assert.Equal(expectedMessage, result);
            Assert.Throws<TranslatableException>(() => new Amount(99));
        }
    }
}
