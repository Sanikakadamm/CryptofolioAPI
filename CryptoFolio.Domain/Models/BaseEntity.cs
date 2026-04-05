using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Domain.Models
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        public int? DeletedBy { get; set; }
    }
}
