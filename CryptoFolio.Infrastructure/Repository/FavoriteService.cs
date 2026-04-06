using AutoMapper;
using CryptoFolio.Application.DTO.Favorite;
using CryptoFolio.Application.Interfaces;
using CryptoFolio.Domain.Models;
using CryptoFolio.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Infrastructure.Repository
{
    
    public class FavoriteService : IFavoriteService
    {
        ApplicationDbContext db;
        IMapper mapper;
        public FavoriteService(ApplicationDbContext db, IMapper mapper)
        {
           this.db = db;
           this.mapper = mapper;
        }
        public void AddFavorite(int userId, AddFavoriteDTO dto)
        {
            var fav = mapper.Map<Favorite>(dto);
            fav.UserId = userId;

            db.Favorites.Add(fav);
            db.SaveChanges();
        }

        public List<FavoriteResponseDTO> GetUserFavorites(int userId)
        {
            var data = db.Favorites
                .Where(x => x.UserId == userId)
                .Include(x => x.CryptoCurrency)
                .ToList();

            var res = mapper.Map<List<FavoriteResponseDTO>>(data);
            return res;
        }

        public void RemoveFavorite(int userId, int cryptoId)
        {
            var fav = db.Favorites
                .FirstOrDefault(x => x.UserId == userId && x.CryptoID == cryptoId);

            if (fav != null)
            {
                db.Favorites.Remove(fav);
                db.SaveChanges();
            }
        }
    }
}
