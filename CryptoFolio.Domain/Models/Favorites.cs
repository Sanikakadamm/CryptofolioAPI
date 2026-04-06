using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Domain.Models
{
    public class Favorite 
    {
        [Key]
        public int FavoriteId { get; set; }

        public int UserId { get; set; }

        public int CryptoID { get; set; }
        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? DeletedBy { get; set; }

        // Navigation
        public User User { get; set; }

        public CryptoCurrency CryptoCurrency { get; set; }
    }
}
