using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.DTO.Transaction
{
    public class TransactionResponseDTO
    {
        public int TransactionId { get; set; }

        public string CoinName { get; set; }

        public string Symbol { get; set; }

        public decimal Quantity { get; set; }

        public decimal PriceAtTrade { get; set; }

        public decimal TotalFiatValue { get; set; }

        public decimal TransactionFee { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
