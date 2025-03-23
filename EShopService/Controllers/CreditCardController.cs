using EShop.Application;
using EShop.Domain.Enums;
using EShop.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController(ICreditCardService creditCardService) : ControllerBase
    {
        private readonly ICreditCardService _creditCardService = creditCardService;

        // GET: api/<CreditCardController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CreditCardController>/4024-0071-6540-1778
        [HttpGet("{cardNumber}")]
        public IActionResult Get(string cardNumber)
        {
            string provider;
            try
            {
                Console.WriteLine("Card number: " + cardNumber + ", length: " + cardNumber.Length);
                _creditCardService.ValidateCard(cardNumber);
                provider = _creditCardService.GetCardType(cardNumber);

                if (!Enum.TryParse<CreditCardProvider>(provider, out _))
                    return StatusCode(406, $"Zły wydawca karty: {provider}");
            } catch(CardNumberTooShortException ex)
            {
                return BadRequest(ex.Message);
            } catch(CardNumberInvalidException ex)
            {
                return BadRequest(ex.Message);
            } catch(CardNumberTooLongException ex)
            {
                return StatusCode(414, ex.Message);
            }
            return Ok($"Provider: {provider}");
        }

        // POST api/<CreditCardController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CreditCardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CreditCardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
