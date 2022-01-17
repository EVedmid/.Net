using BLL.DTO;
using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Controller.Commands.Guest
{
    public class SignUpCommand : ACommand
    {
        private readonly IGuestService _guestService;

        public SignUpCommand(IGuestService guestService) : base(guestService)
        {
            _guestService = guestService;
        }

        public override void Execute()
        {

            Console.Write("Enter a login: ");
            var login = Console.ReadLine();
            Console.Write("Enter a password: ");
            var password = Console.ReadLine();
            Console.Write("Enter an user role (Guest or Manager): ");
            var role = Console.ReadLine();

            if (login != null && !login.Equals(string.Empty) &&
                password != null && !password.Equals(string.Empty) &&
                role != null && !role.Equals(string.Empty))
            {
                var guestDto = new GuestDto
                {
                    Login = login,
                    PasswordHash = password,
                    GuestRole = role
                };

                try
                {
                    _guestService.SignUp(guestDto);
                    Console.WriteLine("User was registered");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }
}
