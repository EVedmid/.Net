using System;
using BLL.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Service.Implementation;

namespace PL.Controller.Commands.Post
{
    public class DeletePost : ACommand
    {
        private readonly IPostService _postService;
        private readonly IGuestService _guestService;

        public DeletePost(IGuestService guestService, IPostService postService) : base(guestService)
        {
            _guestService = guestService;
            _postService = postService;
        }

        public override void Execute()
        {
            try
            {
                AuthorizeAsManager();

                Console.Write("Enter post header: ");
                string header = Console.ReadLine();

                var posts = _postService.FindByHeader(header);
                if (!posts.Any())
                    throw new ValidationService("Invalid header", "");
                else
                {
                    foreach (var x in posts)
                    {
                        Console.WriteLine($"Id {x.Id}");
                        Console.WriteLine($"Header {x.NewsHeader}");
                        Console.WriteLine($"Body {x.NewsBody}");
                    }
                    Console.Write("Enter post id: ");
                    int _id = Convert.ToInt32(Console.ReadLine());
                    _postService.Delete(_id);
                    Console.WriteLine("Done");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
