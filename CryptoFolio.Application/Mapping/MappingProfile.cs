using AutoMapper;
using CryptoFolio.Application.DTO.Auth;
using CryptoFolio.Application.DTO.Crypto;
using CryptoFolio.Application.DTO.Favorite;
using CryptoFolio.Application.DTO.Settings;
using CryptoFolio.Application.DTO.Transaction;
using CryptoFolio.Application.DTO.User;
using CryptoFolio.Application.DTO.UserAsset;
using CryptoFolio.Application.DTO.Wallet;
using CryptoFolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // auth
            CreateMap<RegisterDTO, User>();
            CreateMap<User, AuthResponseDTO>();

            // crypto
            CreateMap<CryptoCurrency, CryptoResponseDTO>();
            CreateMap<CryptoResponseDTO, CryptoCurrency>();

            // fav
            CreateMap<AddFavoriteDTO, Favorite>();
            CreateMap<Favorite, FavoriteResponseDTO>();

            // transaction
            CreateMap<CreateTransactionDTO, Transaction>();
            CreateMap<Transaction, TransactionResponseDTO>();

            // wallet
            CreateMap<AddMoneyDTO, Wallet>();
            CreateMap<Wallet, WalletResponseDTO>();

            // user
            CreateMap<User, UserProfileDTO>();

            // userasset
            CreateMap<UserAsset, UserAssetResponseDTO>();

            // usersettings
            CreateMap<UserSetting, UpdateUserSettingDTO>();
            CreateMap<UpdateUserSettingDTO, UserSetting>();
        }
    }
}
