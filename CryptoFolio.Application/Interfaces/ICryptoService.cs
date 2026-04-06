using CryptoFolio.Application.DTO.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.Interfaces
{
    public interface ICryptoService
    {
        List<CryptoResponseDTO> GetAllCryptos();

        CryptoResponseDTO GetCryptoById(int cryptoId);

        Task<string> GetCoinFromAPI(string coinId);

        Task<string> GetCoinListFromAPI();
    }
}
