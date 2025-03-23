using EShop.Application;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Application.Tests
{
    public class CreditCardServiceTest
    {
        private readonly CreditCardService _service = new CreditCardService();

        [Theory]
        [InlineData("12345678910111213")]
        public void CardLength_Correct(string number)
        {
            Assert.True(_service.ValidateLength(number));
        }

        [Theory]
        [InlineData("1234567890000")]
        public void CardLength_LeftEdgeCase_Correct(string number)
        {
            Assert.True(_service.ValidateLength(number));
        }

        [Theory]
        [InlineData("1111111111111111111")]
        public void CardLength_RightEdgeCase_Correct(string number)
        {
            Assert.True(_service.ValidateLength(number));
        }

        [Theory]
        [InlineData("1")]
        public void CardLength_IncorrectTooShort(string number)
        {
            Assert.Throws<CardNumberTooShortException>(() => _service.ValidateLength(number));
        }

        [Theory]
        [InlineData("11111111111111111111")]
        public void CardLength_IncorrectTooLong(string number)
        {
            Assert.Throws<CardNumberTooLongException>(() => _service.ValidateLength(number));
        }

        [Theory]
        [InlineData("345-470-784-783-010")]
        [InlineData("3497 7965 8312 797")]
        [InlineData("378523393817437")]
        [InlineData("4024-0071-6540-1778")]
        [InlineData("4532 2080 2150 4434")]
        [InlineData("4532289052809181")]
        [InlineData("5530016454538418")]
        [InlineData("5551561443896215")]
        [InlineData("5131208517986691")]
        public void CardValidation_Correct(string number)
        {
            Assert.True(_service.ValidateCard(number));
        }

        [Theory]
        [InlineData("345-470-784-783-01/")]
        [InlineData("3497 7965 8312*797")]
        [InlineData("3785233938174d7")]
        [InlineData("4024-0071-6540=1778")]
        [InlineData("4532 2080 2150+4434")]
        [InlineData("45322890528091i1")]
        [InlineData("553001645453dff8")]
        [InlineData("55515614438962a")]
        [InlineData("5131208517986#91")]
        public void CardValidation_Incorrect(string number)
        {
            Assert.Throws<CardNumberInvalidException>(() => _service.ValidateCard(number));
        }

        [Theory]
        [InlineData("378523393817437", "AmericanExpress")]
        [InlineData("4024-0071-6540-1778", "Visa")]
        [InlineData("4532 2080 2150 4434", "Visa")]
        [InlineData("4532289052809181", "Visa")]
        [InlineData("5530016454538418", "MasterCard")]
        [InlineData("5551561443896215", "MasterCard")]
        [InlineData("5131208517986691", "MasterCard")]
        public void GetCardType_Correct(string cardNumber, string expectedType)
        {
            string actual = _service.GetCardType(cardNumber);
            Assert.Equal(expectedType, actual);
        }
    }
}
