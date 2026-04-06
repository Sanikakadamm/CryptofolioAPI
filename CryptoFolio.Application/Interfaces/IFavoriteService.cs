using CryptoFolio.Application.DTO.Favorite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.Interfaces
{
    public interface IFavoriteService
    {
        void AddFavorite(int userId, AddFavoriteDTO dto);

        void RemoveFavorite(int userId, int cryptoId);

        List<FavoriteResponseDTO> GetUserFavorites(int userId);
    }
}
