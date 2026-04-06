using AutoMapper;
using CryptoFolio.Application.DTO.UserAsset;
using CryptoFolio.Application.Interfaces;
using CryptoFolio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Infrastructure.Repository
{
    public class UserAssetService : IUserAssetService
    {
        ApplicationDbContext db;
        IMapper mapper;

        public UserAssetService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public List<UserAssetResponseDTO> GetUserPortfolio(int userId)
        {
            var data = db.UserAssets
                .Where(x => x.UserId == userId)
                .ToList();

            var res = mapper.Map<List<UserAssetResponseDTO>>(data);

            return res;
        }
    }
}
