using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CryptoFolio.Domain.Models
{
    public class Users : BaseEntity
    {
        [Key]
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        // Navigation Properties
        public Wallet Wallet { get; set; }

        public ICollection<UserAsset> UserAssets { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

        public ICollection<Favorite> Favorites { get; set; }

        public UserSetting UserSetting { get; set; }
    }
}
