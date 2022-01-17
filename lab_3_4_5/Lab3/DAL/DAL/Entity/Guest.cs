using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Guest
    {
        [Key]
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public string GuestRole { get; set; }
    }
}
