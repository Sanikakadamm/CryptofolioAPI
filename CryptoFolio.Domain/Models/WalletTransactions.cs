using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Domain.Models
{
    public class WalletTransaction : BaseEntity
    {
        [Key]
        public int LogId { get; set; }

        public int WalletId { get; set; }

        public decimal Amount { get; set; }

        public string ActionType { get; set; }

        public string Status { get; set; }

        public DateTime TransactionDate { get; set; }

        public string PaymentMethod { get; set; }

        // Navigation
        public Wallet Wallet { get; set; }
    }
}
