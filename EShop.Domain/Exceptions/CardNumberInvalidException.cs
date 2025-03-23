namespace EShop.Domain.Exceptions
{
    public class CardNumberInvalidException : Exception
    {
        public CardNumberInvalidException() : base("Numer karty jest nieprawidłowy"){ }
        public CardNumberInvalidException(string message) : base(message) { }
    }
}
