using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.DTO.Wallet
{
    public class WalletResponseDTO
    {
        public int WalletId { get; set; }

        public decimal AvailableBalance { get; set; }

        public string Currency { get; set; }
    }
}
