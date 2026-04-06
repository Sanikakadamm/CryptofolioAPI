using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Domain.Models
{
    public class CryptoCurrency 
    {
        [Key]
        public int CryptoID { get; set; }

        [Required]
        public string CoinGeckoID { get; set; }
        [Required]
        public string Symbol { get; set; }
        [Required]
        public string CoinName { get; set; }

        public string ImagePath { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? DeletedBy { get; set; }

        // Navigation
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
