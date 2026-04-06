using AutoMapper;
using CryptoFolio.Application.DTO.Settings;
using CryptoFolio.Application.Interfaces;
using CryptoFolio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Infrastructure.Repository
{
    public class UserSettingService : IUserSettingService
    {
        ApplicationDbContext db;
        IMapper mapper;
        public UserSettingService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public UpdateUserSettingDTO GetUserSettings(int userId)
        {
            var data = db.UserSettings
                .FirstOrDefault(x => x.UserId == userId);

            var res = mapper.Map<UpdateUserSettingDTO>(data);

            return res;
        }

        public void UpdateUserSettings(int userId, UpdateUserSettingDTO dto)
        {
            var setting = db.UserSettings
                .FirstOrDefault(x => x.UserId == userId);

            mapper.Map(dto, setting);

            db.UserSettings.Update(setting);
            db.SaveChanges();
        }
    }
}
