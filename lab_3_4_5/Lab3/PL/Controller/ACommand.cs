using BLL.Service;
using BLL.Service.Implementation;
using DAL.Entity;
using System;

namespace PL.Controller
{
    public abstract class ACommand
    {
        private readonly IGuestService _guestService;

        protected ACommand(IGuestService guestService)
        {
            _guestService = guestService;
        }

        public abstract void Execute();

        protected Guest Authorize()
        {
            Console.Write("Enter a login: ");
            var login = Console.ReadLine();
            Console.Write("Enter a password: ");
            var password = Console.ReadLine();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                throw new ValidationService("Invalid credentials", "");
            }

            var guest = _guestService.FindByLogin(login);
            if (guest == null)
            {
                throw new ValidationService("Invalid credentials", "");
            }

            return guest;
        }

        protected void AuthorizeAsManager()
        {
            Console.Write("Enter a login: ");
            var login = Console.ReadLine();
            Console.Write("Enter a password: ");
            var password = Console.ReadLine();
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                var guest = _guestService.FindByLogin(login);
                if (guest == null)
                {
                    throw new ValidationService("Invalid credentials", "");
                }

                if (guest.GuestRole != "Manager")
                {
                    throw new ValidationService("Access permitted", "");
                }
            }
            else
            {
                throw new ValidationService("Invalid credentials", "");
            }
        }
    }
}

