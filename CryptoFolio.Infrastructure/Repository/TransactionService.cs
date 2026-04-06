using AutoMapper;
using CryptoFolio.Application.DTO.Transaction;
using CryptoFolio.Application.Interfaces;
using CryptoFolio.Domain.Models;
using CryptoFolio.Infrastructure.Data;
using CryptoFolio.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Infrastructure.Repository
{
    public class TransactionService : ITransactionService
    {
        ApplicationDbContext db;
        IMapper mapper;
        public TransactionService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void BuyCrypto(int userId, CreateTransactionDTO dto)
        {
            var transaction = mapper.Map<Transaction>(dto);
            transaction.UserId = userId;
            transaction.Type = TransactionType.Buy;

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

        public List<TransactionResponseDTO> GetUserTransactions(int userId)
        {
            var data = db.Transactions
                .Where(x => x.UserId == userId)
                .ToList();

            var res = mapper.Map<List<TransactionResponseDTO>>(data);
            return res;
        }

        public void SellCrypto(int userId, CreateTransactionDTO dto)
        {
            var transaction = mapper.Map<Transaction>(dto);
            transaction.UserId = userId;
            transaction.Type = TransactionType.Sell;

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
    }
}
