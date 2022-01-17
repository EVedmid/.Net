using BLL.DTO;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public interface IGuestService
    {
        void SignUp(GuestDto guestDto);
        Guest FindByLogin(string login);
        public GuestDto FindByLogin_(string login);
        IEnumerable<GuestDto> GetAll();
        void Delete(GuestDto guest);
        void Delete_(string login);
        bool Exists(string login);
    }
}
