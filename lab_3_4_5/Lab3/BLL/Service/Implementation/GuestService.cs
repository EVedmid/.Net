using BLL.DTO;
using DAL.Entity;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Entity.Guest;
using AutoMapper;

namespace BLL.Service.Implementation
{
    public class GuestService : IGuestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GuestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Exists(string login)
        {
            return FindByLogin(login) != null;
        }

        public Guest FindByLogin(string login)
        {
            return _unitOfWork.Guests.FindByLogin(login);
        }

        public GuestDto FindByLogin_(string login)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Guest, GuestDto>()).CreateMapper();
            return mapper.Map<Guest, GuestDto>(_unitOfWork.Guests.FindByLogin(login));
        }

        public void SignUp(GuestDto guestDto)
        {
            if (guestDto.GuestRole is not ("Manager" or "Guest"))
            {
                throw new ValidationService($"Invalid role {guestDto.GuestRole}", "");
            }

            if (Exists(guestDto.Login))
            {
                throw new ValidationService($"User with login {guestDto.Login} already exists", "");
            }

            var guest = new Guest
            {
                Login = guestDto.Login,
                PasswordHash = guestDto.PasswordHash,
                GuestRole = guestDto.GuestRole
            };

            _unitOfWork.Guests.Create(guest);
            _unitOfWork.Save();
        }

        public IEnumerable<GuestDto> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Guest, GuestDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Guest>, List<GuestDto>>(_unitOfWork.Guests.FindAll());
        }

        public void Delete(GuestDto guest)
        {
            if(guest != null)
            {
                _unitOfWork.Guests.RemoveByLogin(guest.Login);
            }
            else
            {
                throw new ValidationService("Invalid guest", "");
            }
        }

        public void Delete_(string login)
        {
            _unitOfWork.Guests.RemoveByLogin(login);
        }
    }
}
