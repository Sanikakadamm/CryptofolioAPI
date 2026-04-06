using CryptoFolio.Application.DTO.Transaction;
using CryptoFolio.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoFolioAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        ITransactionService service;
        public TransactionController(ITransactionService service)
        {
            this.service = service;
        }
        [HttpPost("buy/{userId}")]
        public IActionResult BuyCrypto(int userId, CreateTransactionDTO dto)
        {
            service.BuyCrypto(userId, dto);
            return Ok("Crypto Purchased");
        }

        [HttpPost("sell/{userId}")]
        public IActionResult SellCrypto(int userId, CreateTransactionDTO dto)
        {
            service.SellCrypto(userId, dto);
            return Ok("Crypto Sold");
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserTransactions(int userId)
        {
            var data = service.GetUserTransactions(userId);
            return Ok(data);
        }
    }
}
