namespace EShop.Domain.Exceptions
{
    public class CardNumberTooShortException : Exception
    {
        public CardNumberTooShortException() : base("Numer karty jest za krótki") { }
        public CardNumberTooShortException(string message) : base(message) { }
    }
}
//instalujemy te moduly w EShop.Domain i EShopService