using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GuestDto
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public string GuestRole { get; set; }
    }
}
