using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Domain.Models
{
    public class Wallet : BaseEntity
    {
        [Key]
        public int WalletId { get; set; }

        public int UserId { get; set; }

        public decimal AvailableBalance { get; set; }

        public string Currency { get; set; }

        // Navigation
        public Users User { get; set; }

        public ICollection<WalletTransaction> WalletTransactions { get; set; }
    }
}
