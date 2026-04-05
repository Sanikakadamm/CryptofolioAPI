using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Domain.Models
{
    public class UserSetting
    {
        [Key]
        public int SettingId { get; set; }

        public int UserId { get; set; }

        public bool ThemeMode { get; set; }

        public bool Notifications { get; set; }

        public Users User { get; set; }
    }
}
