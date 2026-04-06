using CryptoFolio.Application.DTO.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.Interfaces
{
    public interface IUserSettingService
    {
        UpdateUserSettingDTO GetUserSettings(int userId);

        void UpdateUserSettings(int userId, UpdateUserSettingDTO dto);
    }
}
