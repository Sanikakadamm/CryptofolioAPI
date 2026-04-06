using CryptoFolio.Application.Interfaces;
using CryptoFolio.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoFolioAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService service;
        public UserController(IUserService service)
        {
            this.service = service;
        }
        [HttpGet("{userId}")]
        public IActionResult GetProfile(int userId)
        {
            var data = service.GetUserProfile(userId);
            return Ok(data);
        }
    }
}
