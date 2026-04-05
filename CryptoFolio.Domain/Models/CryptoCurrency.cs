using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Domain.Models
{
    public class CryptoCurrency : BaseEntity
    {
        [Key]
        public int CryptoID { get; set; }

        public string CoinGeckoID { get; set; }

        public string Symbol { get; set; }

        public string CoinName { get; set; }

        public string ImagePath { get; set; }

        public bool IsActive { get; set; }

        // Navigation
        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<Favorite> Favorites { get; set; }
    }
}
