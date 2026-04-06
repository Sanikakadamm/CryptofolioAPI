using CryptoFolio.Application.DTO.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.Interfaces
{
    public interface ITransactionService
    {
        void BuyCrypto(int userId, CreateTransactionDTO dto);

        void SellCrypto(int userId, CreateTransactionDTO dto);

        List<TransactionResponseDTO> GetUserTransactions(int userId);
    }
}
