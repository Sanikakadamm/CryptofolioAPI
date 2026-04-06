using CryptoFolio.Application.DTO.Auth;
using CryptoFolio.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoFolioAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService service;
        public AuthController(IAuthService service)
        {
            this.service = service;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterDTO dto)
        {
            var res = service.Register(dto);
            return Ok(res);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var res = service.Login(dto);
            return Ok(res);
        }
    }
}
