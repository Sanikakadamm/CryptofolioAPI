using CryptoFolio.Application.DTO.Settings;
using CryptoFolio.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoFolioAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserSettingController : ControllerBase
    {
        IUserSettingService service;
        public UserSettingController(IUserSettingService service)
        {
            this.service = service;
        }
        [HttpGet("{userId}")]
        public IActionResult GetSettings(int userId)
        {
            var data = service.GetUserSettings(userId);
            return Ok(data);
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateSettings(int userId, UpdateUserSettingDTO dto)
        {
            service.UpdateUserSettings(userId, dto);
            return Ok("Settings Updated");
        }
    }
}
