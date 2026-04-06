using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Application.DTO.User
{
    public class UserProfileDTO
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}
