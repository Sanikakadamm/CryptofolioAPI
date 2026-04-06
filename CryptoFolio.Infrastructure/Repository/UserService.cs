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
    internal class UserService 
    {
        ApplicationDbContext db;
        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }
       

        
    }
}
