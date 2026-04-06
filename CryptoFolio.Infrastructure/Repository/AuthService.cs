using AutoMapper;
using BCrypt.Net;
using CryptoFolio.Application.DTO.Auth;
using CryptoFolio.Application.Interfaces;
using CryptoFolio.Domain.Models;
using CryptoFolio.Infrastructure.Data;

namespace CryptoFolio.Infrastructure.Repository
{
    public class AuthService : IAuthService
    {
        ApplicationDbContext db;
        IMapper mapper;
        JwtService jwt;

        public AuthService(ApplicationDbContext db, IMapper mapper, JwtService jwt)
        {
            this.db = db;
            this.mapper = mapper;
            this.jwt = jwt;
        }

        public AuthResponseDTO Register(RegisterDTO dto)
        {
            // Check if email already exists
            var existingUser = db.User.FirstOrDefault(x => x.Email == dto.Email);

            if (existingUser != null)
                throw new Exception("Email already registered");

            var user = mapper.Map<User>(dto);

            // Hash password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            db.User.Add(user);
            db.SaveChanges();

            var res = mapper.Map<AuthResponseDTO>(user);

            return res;
        }

        public AuthResponseDTO Login(LoginDTO dto)
        {
            var user = db.User.FirstOrDefault(x => x.Email == dto.Email);

            if (user == null)
                throw new Exception("User not found");

            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!isValid)
                throw new Exception("Invalid password");

            var token = jwt.GenerateToken(user);

            var res = mapper.Map<AuthResponseDTO>(user);

            res.Token = token;

            return res;
        }
    }
}