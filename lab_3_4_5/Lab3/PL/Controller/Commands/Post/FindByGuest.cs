using System;
using BLL.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Service.Implementation;

namespace PL.Controller.Commands.Post
{
    public class FindByGuest : ACommand
    {
        private readonly IPostService _postService;

        public FindByGuest(IGuestService guestService, IPostService postService) : base(guestService)
        {
            _postService = postService;
        }

        public override void Execute()
        {
            try
            {
                Authorize();
                Console.Write("Enter guest: ");
                string login = Console.ReadLine();

                var posts = _postService.GetAll().Where(post => post.guestLogin == login)
                    .Select(post => post);
                if (!posts.Any())
                {
                    Console.WriteLine("0 posts was found");
                }
                else
                {
                    int count = 0;
                    foreach (var x in posts)
                    {
                        Console.WriteLine($"News number {count + 1}");
                        Console.WriteLine($"Author {x.guestLogin} Time {x.DateTime}");
                        Console.WriteLine($"Tags: {x.Tags}\nTopic: {x.Topic}\nRubric: {x.Rubric}");
                        Console.WriteLine($"Header {x.NewsHeader}\nText:\n{x.NewsBody}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
