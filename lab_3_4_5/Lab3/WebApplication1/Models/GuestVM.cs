using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class GuestVM
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public string Role { get; set; }
    }
}
