using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.DTO.Transaction
{
    public class CreateTransactionDTO
    {
        public int CryptoID { get; set; }

        public decimal Quantity { get; set; }

        public decimal PriceAtTrade { get; set; }
    }
}
