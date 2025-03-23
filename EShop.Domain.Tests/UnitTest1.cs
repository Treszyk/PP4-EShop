
using EShop.Domain.Exceptions;
using System;
using Xunit;

namespace EShop.Domain.Tests
{
    public class ExceptionTests
    {
        [Fact]
        public void CardNumberTooShortException_DefaultMessage()
        {
            var ex = new CardNumberTooShortException();
            Assert.IsType<CardNumberTooShortException>(ex);
            Assert.Equal("Numer karty jest za krótki", ex.Message);
        }

        [Fact]
        public void CardNumberTooLongException_DefaultMessage()
        {
            var ex = new CardNumberTooLongException();
            Assert.IsType<CardNumberTooLongException>(ex);
            Assert.Equal("Numer karty jest za długi", ex.Message);
        }

        [Fact]
        public void CardNumberInvalidException_DefaultMessage()
        {
            var ex = new CardNumberInvalidException();
            Assert.IsType<CardNumberInvalidException>(ex);
            Assert.Equal("Numer karty jest nieprawidłowy", ex.Message);
        }
    }
}
