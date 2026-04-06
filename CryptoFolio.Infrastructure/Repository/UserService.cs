using AutoMapper;
using CryptoFolio.Application.DTO.Auth;
using CryptoFolio.Application.DTO.User;
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
    public class UserService : IUserService
    {
        ApplicationDbContext db;
        IMapper mapper;
        public UserService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public UserProfileDTO GetUserProfile(int userId)
        {
            var data = db.User.Find(userId);

            var res = mapper.Map<UserProfileDTO>(data);

            return res;
        }
    }
}
