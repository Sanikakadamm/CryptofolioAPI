using AutoMapper;
using CryptoFolio.Application.DTO.Wallet;
using CryptoFolio.Application.Interfaces;
using CryptoFolio.Domain.Models;
using CryptoFolio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Infrastructure.Repository
{
    public class WalletService : IWalletService
    {
        ApplicationDbContext db;
        IMapper mapper;
        public WalletService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddMoney(int userId, AddMoneyDTO dto)
        {
            var wallet = db.Wallets.FirstOrDefault(x => x.UserId == userId);

            if (wallet == null)
                throw new Exception("Wallet not found");

            wallet.AvailableBalance += dto.Amount;

            db.SaveChanges();
        }

        public WalletResponseDTO GetWallet(int userId)
        {
            var data = db.Wallets.Find(userId);
            var res = mapper.Map<WalletResponseDTO>(data);
            return res;
        }
    }
}
