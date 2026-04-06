using CryptoFolio.Application.DTO.Favorite;
using CryptoFolio.Application.Interfaces;
using CryptoFolio.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoFolioAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        IFavoriteService service;
        public FavoriteController(IFavoriteService service)
        {
            this.service = service;
        }
        [HttpPost("{userId}")]
        [Authorize]
        public IActionResult AddFavorite(int userId, AddFavoriteDTO dto)
        {
            service.AddFavorite(userId, dto);
            return Ok("Added to Favorites");
        }

        [HttpGet("{userId}")]
        public IActionResult GetFavorites(int userId)
        {
            var data = service.GetUserFavorites(userId);
            return Ok(data);
        }

        [HttpDelete("{userId}/{cryptoId}")]
        public IActionResult RemoveFavorite(int userId, int cryptoId)
        {
            service.RemoveFavorite(userId, cryptoId);
            return Ok("Removed from Favorites");
        }
    }
}
