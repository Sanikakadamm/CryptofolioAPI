using CryptoFolio.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.Interfaces
{
    public interface IUserService
    {
        UserProfileDTO GetUserProfile(int userId);
    }
}
