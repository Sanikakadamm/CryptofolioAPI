using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.DTO.Crypto
{
    public class CryptoResponseDTO
    {
        public int CryptoID { get; set; }

        public string Symbol { get; set; }

        public string CoinName { get; set; }

        public string ImagePath { get; set; }

        public bool IsActive { get; set; }
    }
}
