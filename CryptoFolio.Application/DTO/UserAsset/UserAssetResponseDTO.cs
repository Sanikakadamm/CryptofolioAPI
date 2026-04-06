using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.DTO.UserAsset
{
    public class UserAssetResponseDTO
    {
        public int CryptoID { get; set; }

        public string CoinName { get; set; }

        public string Symbol { get; set; }

        public decimal Quantity { get; set; }

        public decimal AverageBuyPrice { get; set; }
    }
}
