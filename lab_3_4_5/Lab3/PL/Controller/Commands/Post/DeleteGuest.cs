using System;
using BLL.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Service.Implementation;

namespace PL.Controller.Commands.Post
{
    public class DeleteGuest : ACommand
    {
        private readonly IGuestService _guestService;

        public DeleteGuest(IGuestService guestService) : base(guestService)
        {
            _guestService = guestService;
        }

        public override void Execute()
        {
            try
            {
                AuthorizeAsManager();

                Console.Write("Enter guest login: ");
                string login = Console.ReadLine();

                if(!_guestService.Exists(login))
                {
                    throw new ValidationService("Guest not found", "");
                }
                else
                {
                    var guest = _guestService.FindByLogin(login);
                    //_guestService.Delete(guest);
                    Console.WriteLine("Done!");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
