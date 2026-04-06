using CryptoFolio.Application.DTO.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.Interfaces
{
    public interface IWalletService
    {
        WalletResponseDTO GetWallet(int userId);

        void AddMoney(int userId, AddMoneyDTO dto);
    }
}
