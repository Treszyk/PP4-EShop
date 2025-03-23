namespace EShop.Application
{
    public interface ICreditCardService
    {
        bool ValidateLength(string cardNumber);
        bool ValidateCard(string cardNumber);
        string GetCardType(string cardNumber);
    }
}
