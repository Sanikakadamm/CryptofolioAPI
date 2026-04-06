using AutoMapper;
using CryptoFolio.Application.DTO.Auth;
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
    public class AuthService : IAuthService
    {
        ApplicationDbContext db;
        IMapper mapper;

        public AuthService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        AuthResponseDTO IAuthService.Register(RegisterDTO dto)
        {
            var user = mapper.Map<User>(dto);

            db.User.Add(user);
            db.SaveChanges();

            var res = mapper.Map<AuthResponseDTO>(user);

            return res;
        }

        AuthResponseDTO IAuthService.Login(LoginDTO dto)
        {
            var user = db.User
                .FirstOrDefault(x => x.Email == dto.Email && x.PasswordHash == dto.Password);

            if (user == null)
                throw new Exception("Invalid Credentials");

            var res = mapper.Map<AuthResponseDTO>(user);
            return res;
        }
    }
}
