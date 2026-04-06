using CryptoFolio.Application.DTO.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.Interfaces
{
    public interface IAuthService
    {
        AuthResponseDTO Register(RegisterDTO dto);

        AuthResponseDTO Login(LoginDTO dto);
    }
}
