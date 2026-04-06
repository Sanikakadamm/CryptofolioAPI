using CryptoFolio.Application.DTO.Wallet;
using CryptoFolio.Application.Interfaces;
using CryptoFolio.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoFolioAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        IWalletService service;
        public WalletController(IWalletService service)
        {
            this.service = service;
        }
        [HttpGet("{userId}")]
        [Authorize]
        public IActionResult GetWallet(int userId)
        {
            var data = service.GetWallet(userId);
            return Ok(data);
        }

        [HttpPost("addmoney/{userId}")]
        public IActionResult AddMoney(int userId, AddMoneyDTO dto)
        {
            service.AddMoney(userId, dto);
            return Ok("Money Added Successfully");
        }
    }
}
