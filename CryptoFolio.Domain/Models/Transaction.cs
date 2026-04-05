using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoFolio.Domain.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public int UserId { get; set; }

        public int CryptoID { get; set; }   

        public string Type { get; set; }

        public decimal Quantity { get; set; }

        public decimal PriceAtTrade { get; set; }

        public decimal TotalFiatValue { get; set; }

        public decimal TransactionFee { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation
        public Users User { get; set; }

        public CryptoCurrency CryptoCurrency { get; set; } // Navigation Property
    }
}