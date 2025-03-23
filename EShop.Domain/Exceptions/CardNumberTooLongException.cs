namespace EShop.Domain.Exceptions
{
    public class CardNumberTooLongException : Exception
    {
        public CardNumberTooLongException() : base("Numer karty jest za długi") { }
        public CardNumberTooLongException(string message) : base(message) { }

    }
}
