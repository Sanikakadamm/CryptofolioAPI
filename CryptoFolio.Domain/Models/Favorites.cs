using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Domain.Models
{
    public class Favorite : BaseEntity
    {
        [Key]
        public int FavoriteId { get; set; }

        public int UserId { get; set; }

        public int CryptoID { get; set; }

        // Navigation
        public Users User { get; set; }

        public CryptoCurrency CryptoCurrency { get; set; }
    }
}
