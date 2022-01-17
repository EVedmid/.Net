using System;
using BLL.DTO;
using BLL.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Controller.Commands.Post
{
    public class GetAllPosts : ACommand
    {
        private readonly IPostService _postService;

        public GetAllPosts(IGuestService guestService ,IPostService postService) : base(guestService)
        {
            _postService = postService;
        }

        public override void Execute()
        {
            try
            {
                int count = 0;
                var posts = _postService.GetAll();
                if(!posts.Any())
                    Console.WriteLine("0 posts was found");
                else
                {
                    foreach (var x in posts)
                    {
                        Console.WriteLine($"News number {count + 1}");
                        Console.WriteLine($"Author {x.guestLogin} Time {x.DateTime}");
                        Console.WriteLine($"Tags: {x.Tags}\nTopic: {x.Topic}\nRubric: {x.Rubric}");
                        Console.WriteLine($"Header {x.NewsHeader}\nText:\n{x.NewsBody}");
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
