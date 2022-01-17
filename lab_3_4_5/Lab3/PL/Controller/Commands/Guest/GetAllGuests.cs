using System;
using BLL.DTO;
using BLL.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Service.Implementation;

namespace PL.Controller.Commands.Guest
{
    public class GetAllGuests : ACommand
    {
        private readonly IGuestService _guestService;

        public GetAllGuests(IGuestService guestService) : base(guestService) 
        {
            _guestService = guestService;
        }

        public override void Execute()
        {
            try
            {
                AuthorizeAsManager();

                var guests = _guestService.GetAll();

                if (guests == null)
                    throw new ValidationService("0 guests", "");
                else
                {
                    int count = 0;
                    foreach (var x in guests)
                    {
                        Console.WriteLine($"Count {count + 1 }");
                        Console.WriteLine($"Login {x.Login}, {x.GuestRole}");
                        count++;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
