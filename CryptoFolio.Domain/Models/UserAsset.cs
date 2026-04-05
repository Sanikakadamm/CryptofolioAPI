using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Domain.Models
{
    public class UserAsset : BaseEntity
    {
        [Key]
        public int AssetId { get; set; }

        public int UserId { get; set; }

        public string Symbol { get; set; }

        public decimal Quantity { get; set; }

        public decimal AverageBuyPrice { get; set; }

        // Navigation
        public Users User { get; set; }
    }
}
