using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CryptoFolio.Domain.Models
{
    public class User 
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? DeletedBy { get; set; }

        // Navigation Properties
        public Wallet Wallet { get; set; }

        public ICollection<UserAsset> UserAssets { get; set; } = new List<UserAsset>();

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

        public UserSetting UserSetting { get; set; } 
    }
}
