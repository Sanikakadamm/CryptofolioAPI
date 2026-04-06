using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.DTO.Auth
{
    public class AuthResponseDTO
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
