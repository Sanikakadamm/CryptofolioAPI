using CryptoFolio.Application.DTO.UserAsset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.Interfaces
{
    public interface IUserAssetService
    {
        List<UserAssetResponseDTO> GetUserPortfolio(int userId);
    }
}
