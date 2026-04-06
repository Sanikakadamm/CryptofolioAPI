using CryptoFolio.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CryptoFolioAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService service;

        public CryptoController(ICryptoService service)
        {
            this.service = service;
        }

        // 🔐 Get all cryptos from DB
        [HttpGet]
        [Authorize]
        public IActionResult GetAllCryptos()
        {
            var data = service.GetAllCryptos();
            return Ok(data);
        }

        // 🔐 Get crypto by id from DB
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetCryptoById(int id)
        {
            var data = service.GetCryptoById(id);
            return Ok(data);
        }

        // 🌐 Get specific coin from CoinGecko
        [HttpGet("api-coin/{coinId}")]
        public async Task<IActionResult> GetCoin(string coinId)
        {
            var data = await service.GetCoinFromAPI(coinId);
            return Ok(data);
        }

        // 🌐 Get full coin list from CoinGecko
        [HttpGet("api-coins")]
        public async Task<IActionResult> GetCoins()
        {
            var data = await service.GetCoinListFromAPI();
            return Ok(data);
        }
    }
}