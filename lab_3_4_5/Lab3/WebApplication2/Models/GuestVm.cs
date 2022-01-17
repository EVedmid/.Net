using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class GuestVm
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public string GuestRole { get; set; }

    }
}
